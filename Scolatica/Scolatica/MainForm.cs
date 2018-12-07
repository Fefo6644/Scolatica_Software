/*
 * 
 * Este programa fue creado para aplicarse a la materia de Prácticas Profesionalizantes de 7° año de Electrónica,
 * diseñado con fines prácticos dentro de la escuela.
 * 
 * 
 * 
 * Diseñado y desarrollado por:
 *	- Claro Nicolás
 *	- Di Tullio Julián
 *	- Gómez Cardozo María Celeste
 *	- Iglesias Rodrigo Nicolás
 *	- López Ferro Federico
 * 
 * Ante cualquier duda o consulta, comunicarse a 'scolatica.chaparral@gmail.com'
 * 
 *
 *
 *
 *
 *
 *
 * no pienso comentar todo... es mucho... con comentar las funciones ya es suficiente...
 *
 *
 *
 *
 *
 *
 */

// 
// Librerías cargadas (aunque no son librerías, tienen un funcionamiento similar).
// 
using System;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Scolatica
{
    public partial class MainForm : Form
    {
		// 
		// Utilizado para el modo de depuración.
		// 
        bool DebugMode { get; set; }
        ulong Line { get; set; }

        // 
        // Variables.
        // 
        bool isConnected = false, aulaOcupada = false;
        string[] Ports;
        string inputData = string.Empty, codigoProfesor = string.Empty;
        int horarioSalida;
        Thread salida;

        /// <summary>
        /// Lee por el Serial Port cuando recibe información y lee del XML.
        /// </summary>
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (InvokeRequired)
            {
				// 
				// Espera 10ms así llega toda la información al puerto serial.
				// 
                Thread.Sleep(10);
                inputData = SerialPort.ReadExisting().Replace(Environment.NewLine, string.Empty);
                Invoke(new Action<object, SerialDataReceivedEventArgs>(SerialPort_DataReceived), new object[] { sender, e });
                return;
            }

            if (DebugMode)
            {
                tbDebugger.Text += inputData + "\r\n";
                return;
            }

            foreach (XElement level1Element in XElement.Load("DatosProfesores.xml").Elements("Profesor"))
            {
                if (level1Element.Attribute("codigo").Value == inputData)
                {
                    if (aulaOcupada && codigoProfesor == inputData)
                    {
                        aulaOcupada = false;
                        lab6.Text = "Lab. 6";
                        codigoProfesor = string.Empty;
                    }
                    else if (!aulaOcupada && codigoProfesor == string.Empty)
                    {
                        // Hora actual
                        int hora = DateTime.Now.Hour * 100 + DateTime.Now.Minute;

                        foreach (XElement level2Element in level1Element.Elements('_' + ((int)DateTime.Today.DayOfWeek).ToString()))
                        {
                            if (level2Element.Attribute("disponible").Value == "SI")
                            {
                                // Verifica que la hora actual esté dentro del horario del docente
                                if ((int.Parse(level2Element.Attribute("desde").Value) - 5 <= hora) &&
                                    (int.Parse(level2Element.Attribute("hasta").Value) > hora))
                                {
                                    aulaOcupada = true;
                                    codigoProfesor = inputData;
                                    horarioSalida = int.Parse(level2Element.Attribute("hasta").Value) + 5;

                                    salida = new Thread(() => Salida());

                                    lab6.Text = "Lab. 6 - Profesor " + level1Element.Attribute("nombre").Value +
                                                    " - Curso " + level2Element.Attribute("curso").Value;
                                    break;
                                }
                            }
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Aunque el docente no pase tarjeta a la salida,
        /// pasado 5 minutos el horario de salida, se limpia solo.
        /// </summary>
        private void Salida()
        {
            while ((horarioSalida < (DateTime.Now.Hour * 100 + DateTime.Now.Minute)) && aulaOcupada && codigoProfesor != string.Empty)
                Thread.Sleep(30000);
            lab6.Text = "Lab. 6";
            codigoProfesor = string.Empty;
            aulaOcupada = false;
        }

        /*
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * OTROS
		 *
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 *
		 */

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainForm(string[] args)
        {
            InitializeComponent();

            if (args.Length == 1 && args[0] == "-DEBUG")
            {
                DebugMode = true;
                Line = 0;
                mainPanel.Dispose();
            }
            else
            {
                DebugMode = false;
                tbDebugger.Dispose();
            }

            SerialPort.BaudRate = 9600;
            CbPorts_DropDown(null, null);
        }

        /// <summary>
        /// Le hace el reborde azul/verde.
        /// </summary>
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (!DebugMode)
            {
                var graphics = CreateGraphics();
                Pen pen = new Pen(Color.CadetBlue, 4);
                Rectangle rectangle = new Rectangle(mainPanel.Left - 1, mainPanel.Top - 1, mainPanel.Width + 2, mainPanel.Height + 2);
                graphics.DrawRectangle(pen, rectangle);
            }
        }

        /// <summary>
        /// Al 'disparar' el listado, lee los puertos disponibles y los añade a la lista.
        /// </summary>
        private void CbPorts_DropDown(object sender, EventArgs e)
        {
            cbPorts.Items.Clear();
            Ports = SerialPort.GetPortNames();

            if (Ports.Length > 0)
            {
                btnConnect.Enabled = true;

                foreach (string port in Ports)
                    cbPorts.Items.Add(port);

                cbPorts.SelectedItem = Ports[0];
            }
            else
                btnConnect.Enabled = false;
        }

        /// <summary>
        /// Cuando se hace clic en el botón de Conectar/Desconectar
        /// se conecta o desconecta de ese puerto y hace otras cosas.
        /// </summary>
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                try
                {
                    string selectedPort = cbPorts.GetItemText(cbPorts.SelectedItem);
                    SerialPort.PortName = selectedPort;
                    SerialPort.Open();
                    isConnected = true;
                    btnConnect.Text = "Desconectar";
                    cbPorts.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CbPorts_DropDown(null, null);
                }
            }
            else if (isConnected)
            {
                try
                {
                    SerialPort.Close();
                    isConnected = false;
                    btnConnect.Text = "Conectar";
                    CbPorts_DropDown(null, null);
                    cbPorts.Enabled = true;

                    if (DebugMode)
                    {
                        tbDebugger.Text = string.Empty;
                        return;
                    }

                    lab1.Text = "Lab. 1";
                    lab1b.Text = "Lab. 1b";
                    lab2.Text = "Lab. 2";
                    lab3.Text = "Lab. 3";
                    lab4.Text = "Lab. 4";
                    lab5.Text = "Lab. 5";
                    lab6.Text = "Lab. 6";
                    lab7.Text = "Lab. 7";
                    lab8.Text = "Lab. 8";
                    lab9.Text = "Lab. 9";

                    aulaOcupada = false;
                    codigoProfesor = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CbPorts_DropDown(null, null);
                }
            }
        }

        /// <summary>
        /// Al cerrar el aplicativo, me aseguro de que se cierre el puerto usado si está abierto.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isConnected)
                BtnConnect_Click(sender, e);
        }
    }
}
