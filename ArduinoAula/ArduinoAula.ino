/*
   ----------------------------------
               MFRC522      Arduino
               Reader/PCD   Uno/101
   Signal      Pin          Pin
   ----------------------------------
   RST/Reset   RST          9
   SPI SS      SDA(SS)      10
   SPI MOSI    MOSI         11
   SPI MISO    MISO         12
   SPI SCK     SCK          13
*/

/*  Incluye la librería del módulo RFID */
#include <MFRC522.h>

/*  Pines de Reset y "Slave Select" para el MFRC522 */
#define RST_PIN 9
#define SS_PIN  10

/*  Velocidad de transmisión en bps (bits por segundo) entre Arduinos  */
#define TX_RATE 256

/*  Pines de clock, data y SS para comunicación entre Arduinos  */
#define TX_CLOCK  2
#define TX_DATA   3
#define RX_SS     4

/*  El bonito botón */
#define PIN_BTN 5

/*  Pin utilizado para el buzzer */
#define PIN_BUZZER 6

/*  Interfaz de comunicación con el RFID  */
MFRC522 rfid(SS_PIN, RST_PIN);

/*  Variable booleana; indica si se terminó de leer el PICC
    (Proximity Integrated Circuit Card)  */
bool rfid_ready = false;

byte uid_len;
byte* data; /* Puntero a un array de bytes en el que se guarda
               el ID del PICC  */

bool start = false;

void setup()
{
  /*  Clock es un pin de recepción y data de transmisión  */
  pinMode(TX_CLOCK,   OUTPUT);
  pinMode(TX_DATA,    OUTPUT);
  pinMode(PIN_BUZZER, OUTPUT);
  pinMode(RX_SS,      INPUT );

  /*  Utilizado para el botón (sólo inicia comunicación entre
  	los Arduinos luego de presionar el botón, para que no
  	haya desfasaje de datos)  */
  pinMode(PIN_BTN,    INPUT );

  /*  Inicia la comunicación con el RFID  */
  SPI.begin();
  rfid.PCD_Init();
  rfid.PCD_SetAntennaGain(rfid.RxGain_max);
}

void loop()
{
  // Lee el PICC
  readRFID();

  /* Si se presiona el botón, se habilita la comunicación
     entre los Arduinos */
  if (digitalRead(PIN_BTN))
    start = true;


  /* Funciona de la siguiente manera:
    - El Arduino del aula lee PICC.
    - El Arduino de la PC (central) le pide información mediante RX_SS.
	- Si hay información para enviar, envía bit por bit en serie por TX_DATA
        marcando el ritmo con TX_CLOCK a la velocidad de TX_RATE. Luego envía
        el byte de cierre (0x55).
    - Si no hay información, envía el byte de cierre (0x55).
    - Si el Arduino central no le pide información, el Arduino del aula no lee
        PICC hasta no enviar la información.
    - Se repite el proceso cíclicamente.
  */

  if (digitalRead(RX_SS) && start)
  {
    if (rfid_ready)
    {
      digitalWrite(PIN_BUZZER, HIGH);

      for (int byte_index = 0; byte_index < uid_len; byte_index++)
      {
        byte tx_byte = data[byte_index];

        for (int bit_index = 0; bit_index < 8; bit_index++)
        {
          bool tx_bit = tx_byte & (0x80 >> bit_index);  //
                                                        //
          digitalWrite(TX_DATA, tx_bit);                //  Envía el ID del PICC bit por bit
          delay((1000 / TX_RATE) / 2);                  //
                                                        //
          digitalWrite(TX_CLOCK, HIGH);
          delay((1000 / TX_RATE) / 2);
          digitalWrite(TX_CLOCK, LOW);
        }
      }
      rfid_ready = false;
      delete[] data;
    }

    for (int i = 0; i < 8; i++)
    {
      digitalWrite(TX_DATA, i % 2);  //
      delay((1000 / TX_RATE) / 2);   // Envía el byte de cierre (0x55) bit por bit
                                     //
      digitalWrite(TX_CLOCK, HIGH);
      delay((1000 / TX_RATE) / 2);
      digitalWrite(TX_CLOCK, LOW);
    }
    digitalWrite(TX_DATA, LOW);
    delay(333);
    digitalWrite(PIN_BUZZER, LOW);
  }
}


/*  Función para leer el PICC  */
void readRFID()
{
  /*  Solo funciona si no leyó un PICC anteriormente  */
  if (!rfid_ready)
  {
    /*  Detecta si hay un PICC esperando a ser leído.
        Si no lo hay, no hace nada  */
    if (!rfid.PICC_IsNewCardPresent())
      return;

    /*  Detecta si puede leer el UID del PICC presente.
        Si no puede, no hace nada */
    if (!rfid.PICC_ReadCardSerial())
      return;

    uid_len = rfid.uid.size;
    data = new byte[uid_len];

    /*  Guarda byte por byte el ID del PICC en un array
    	indicado por un puntero */
    for (int byte_index = 0; byte_index < uid_len; byte_index++)
      data[byte_index] = rfid.uid.uidByte[byte_index];

    rfid.PICC_HaltA();

    rfid_ready = true;
  }
}
