/*
 * 
 * Este programa es una modificación
 * del programa receptor demostrado en el siguiente video:
 * https://www.youtube.com/watch?v=eq5YpKHXJDM
 * 
 * Recomendo mirarlo al que sepa inglés.
 * 
 */

// Asignación de pines
#define RX_CLOCK 2  //  Por donde recibe los pulsos de clock.
#define RX_DATA 3   //  Por donde recibe la información.
#define TX_SELECT 4 //  En realidad, debería ser un array de pines (uno por cada aula)
                    //  pero solo lo hicimos en el lab 6, entonces solo tiene un Arduino
                    //  para pedirle información.

byte data[16];      //  En este array de bytes se guarda la información, pero debería ser
                    //  un array de arrays (uno por cada aula).
volatile byte rx_byte = 0;
volatile int bit_position = 0;
volatile bool recieved = false;

void setup()
{
  pinMode(RX_DATA, INPUT);
  pinMode(TX_SELECT, OUTPUT);
  strcpy(data, "");
  attachInterrupt(digitalPinToInterrupt(RX_CLOCK), onClockPulse, RISING);
  //  Recibe la información mediante interrupciones marcadas por el clock.

  Serial.begin(9600);

  digitalWrite(TX_SELECT, HIGH);
}

//  Les recomiendo simular este código en su cabeza para poder entenderlo bien.
void onClockPulse()
{
  bool rx_bit = digitalRead(RX_DATA);

  if (bit_position == 8)
  {
    rx_byte = 0x00;
    bit_position = 0;
  }

  if (rx_bit)
    rx_byte |= (0x80 >> bit_position);  //  Va recibiendo bit a bit y lo va desplazando en el byte rx_byte.

  bit_position++;

  if (bit_position == 8)
  {
    if (rx_byte == 0x55)  //  Byte de cierre
    {
      recieved = true;
      return;
    }
    strncat(data, (const char*)&rx_byte, 1);
  }
}

void loop()
{ //  Envía la información a la PC si le llegó el byte de cierre
  //  Lo envía byte por byte.
  if (recieved)
  {
    recieved = false;
    digitalWrite(TX_SELECT, LOW);

    if (strlen(data) > 0)
    {
      for (int i = 0; i < strlen(data); i++)
        Serial.print(data[i], HEX);
      Serial.println();
    }
    strcpy(data, "");

    delay(1);
    digitalWrite(TX_SELECT, HIGH);
  }

  //  Idealmente, iría iterando entre todos los Arduinos, pero hay uno solo ¯\_(ツ)_/¯
}
