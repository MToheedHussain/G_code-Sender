using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace Serial
{

    public partial class MainForm : Form
    {
        private bool isAutoSendMode = false;
        #region Constant
        private readonly int[] baudrate = { 9600, 19200, 38400, 115200, 230400, 460800, 921600, 3860000 };
        #endregion

        private readonly SerialPort Serial = new SerialPort();

        #region Local Helpers
        private void UpdateCOMPortList()
        {
            // Get all existing Com Port names
            string[] Ports = System.IO.Ports.SerialPort.GetPortNames();
            cboxComport.Items.Clear();
            cboxBaudrate.Items.Clear();

            // Append existing COM to the cboxComport list
            foreach (var item in Ports)
            {
                cboxComport.Items.Add(item);
            }

            // Append possible Baudrate to the cboxBaudrate list
            foreach (var baud in baudrate)
            {
                cboxBaudrate.Items.Add(baud.ToString());
            }
        }
        #endregion

        #region Delegates
        public delegate void UPDATE_OUTPUT_TEXT(String Str);
        public void UpdateOutputText(String Str)
        {
            tboxReceive.Text += Str;
            tboxReceive.ScrollToCaret();
        }
        #endregion


        #region Handlers
        void SerialOnReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            String str = Serial.ReadExisting();

            Invoke(new UPDATE_OUTPUT_TEXT(UpdateOutputText), str);
        }
        #endregion
       
        public MainForm()
        {
            InitializeComponent();
          
            tboxData.ScrollBars = ScrollBars.Both; // Add this line to enable scrollbars
            tboxReceive.ScrollBars = ScrollBars.Both; // Add this line to enable scrollbars
            tboxData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            tboxReceive.Anchor = AnchorStyles.Top |  AnchorStyles.Bottom;

        }


        private void BtnConnect_Click(object sender, EventArgs e)
        {
            // If user click disconnect
            if ("Disconnect" == btnConnect.Text.ToString())
            {
                if (true == Serial.IsOpen)
                {
                    Serial.Close();
                }

                btnConnect.Text = "Connect";
                cboxComport.Enabled = true;
                cboxBaudrate.Enabled = true;
                btnRefresh.Enabled = true;

                return;
            }

            // else we gonna open the desired COM port
            // Get user comport from cbox
            try
            {
                Serial.PortName = cboxComport.Text;
            }
            catch
            {
                MessageBox.Show("Error! No COM Port selected");
                return;
            }

            // Get user baudrate from cbox
            try
            {
                Serial.BaudRate = int.Parse(cboxBaudrate.Text.ToString());
            }
            catch
            {
                MessageBox.Show("Error! No Baudrate selected");
                return;
            }

            // Serial Port Configuration
            Serial.Parity = Parity.None;
            Serial.DataBits = 8;
            Serial.ReceivedBytesThreshold = 1;
            Serial.StopBits = StopBits.One;
            Serial.Handshake = Handshake.None;
            Serial.WriteTimeout = 3000;

            // Check if com port is opened by other application
            if (false == Serial.IsOpen)
            {
                try
                {
                    // Com port available
                    Serial.Open();
                }
                catch
                {
                    MessageBox.Show("The COM port is not accessible", "Error");
                    return;
                };


                // double comform it is opened
                if (true == Serial.IsOpen)
                {
                    btnConnect.Text = "Disconnect";
                    cboxComport.Enabled = false;
                    cboxBaudrate.Enabled = false;
                    btnRefresh.Enabled = false;

                    // Add callback handler for receiving
                    Serial.DataReceived += new SerialDataReceivedEventHandler(SerialOnReceivedHandler);

                }

            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // We need to populate the lists during mainform is loading
            UpdateCOMPortList();
        }

        private void BtnRefresh_Click(object sender,
                                      EventArgs e)
        {
            // We need to update all lists again if user requested
            UpdateCOMPortList();
        }
        
        private string[] gcodeLines;
        private int currentLineIndex;

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "G-code Files|*.gcode;*.txt|All Files|*.*",
                Title = "Select a G-code File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                textBoxFilePath.Text = selectedFilePath;

                // Read the G-code lines into an array
                gcodeLines = File.ReadAllLines(selectedFilePath);
                currentLineIndex = 0;

            }
        }
       

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (isSendingGcode)
            {
                MessageBox.Show("Sending data in progress. Please stop the current sending process before initiating a new one.", "Sending in Progress", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (gcodeLines == null)
            {
                MessageBox.Show("Please select a G-code file first.");
                return;
            }

            if (null != Serial)
            {
                if (true == Serial.IsOpen)
                {
                    int linesToSend = Convert.ToInt32(numericUpDownLines.Value);

                    if (linesToSend > 0)
                    {
                        int remainingLines = gcodeLines.Length - currentLineIndex;
                        linesToSend = Math.Min(linesToSend, remainingLines);

                        for (int i = 0; i < linesToSend; i++)
                        {
                            string line = gcodeLines[currentLineIndex];
                            Serial.WriteLine(line);

                            // Append the sent line to the tboxData TextBox
                            tboxData.Text += line + Environment.NewLine;
                            tboxData.SelectionStart = tboxData.Text.Length;
                            tboxData.ScrollToCaret();
                            Application.DoEvents(); // Allow the UI to update

                            currentLineIndex++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid number of lines.");
                    }
                }
                else
                {
                    MessageBox.Show("COM Port is not Opened");
                }
            }

        }




        private void BtnNumberOfLines_Click(object sender, EventArgs e)
        {
            // Show a prompt for the user to enter the number of lines to send
            using (var prompt = new Form())
            {
                prompt.Text = "Enter Number of Lines";
                prompt.StartPosition = FormStartPosition.CenterParent;

                var label = new Label() { Left = 20, Top = 20, Text = "Number of Lines:" };
                var numericUpDown = new NumericUpDown() { Left = 150, Top = 20, Width = 100 };
                var confirmButton = new Button() { Text = "OK", Left = 150, Width = 100, Top = 50, DialogResult = DialogResult.OK };

                prompt.Controls.Add(numericUpDown);
                prompt.Controls.Add(confirmButton);
                prompt.Controls.Add(label);

                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    numericUpDownLines.Value = numericUpDown.Value;
                }
            }
        }
        private int storedLineIndex;

        private void BtnSendGcode_Click(object sender, EventArgs e)
        {
            if (gcodeLines == null)
            {
                MessageBox.Show("Please select a G-code file first.");
                return;
            }

            if (null == Serial)
            {
                return;
            }
            if (true != Serial.IsOpen)
            {
                MessageBox.Show("COM Port is not Opened");
            }
            else
            {
                // Start sending G-code lines with a 10ms delay
                isSendingGcode = true;
                currentLineIndex = storedLineIndex; // Resume from stored index
                timerSendGcode.Start();
            }
        }


        private bool isSendingGcode = false;

        private void TimerSendGcode_Tick(object sender, EventArgs e)
        {
            if (currentLineIndex < gcodeLines.Length && isSendingGcode)
            {
                string line = gcodeLines[currentLineIndex];
                Serial.WriteLine(line);

                // Append the sent line to the tboxData TextBox
                tboxData.Text += line + Environment.NewLine;
                tboxData.SelectionStart = tboxData.Text.Length;
                tboxData.ScrollToCaret();
                Application.DoEvents(); // Allow the UI to update

                currentLineIndex++;

                if (currentLineIndex >= gcodeLines.Length)
                {
                    // All lines have been sent
                    isSendingGcode = false;
                    MessageBox.Show("All lines have been sent.");
                }
            }
        }

        private void BtnStopSending_Click(object sender, EventArgs e)
        {
            // Stop sending G-code lines
            isSendingGcode = false;
            timerSendGcode.Stop();

            // Store the current line index
            storedLineIndex = currentLineIndex;
        }


        private void BtnSendAllAtOnce_Click(object sender, EventArgs e)
        {
            if (isSendingGcode)
            {
                MessageBox.Show("Sending data in progress. Please stop the current sending process before initiating a new one.", "Sending in Progress", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (gcodeLines == null)
            {
                MessageBox.Show("Please select a G-code file first.");
                return;
            }

            if (null != Serial)
            {
                if (true == Serial.IsOpen)
                {
                    foreach (string line in gcodeLines)
                    {
                        Serial.WriteLine(line);

                        // Append the sent line to the tboxData TextBox
                        tboxData.Text += line + Environment.NewLine;
                        tboxData.SelectionStart = tboxData.Text.Length;
                        tboxData.ScrollToCaret();
                        Application.DoEvents(); // Allow the UI to update
                    }

                    MessageBox.Show("All lines have been sent.");
                }
                else
                {
                    MessageBox.Show("COM Port is not Opened");
                }
            }
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            string aboutMessage = "Serial Communication Application\n"
                                + "University of Engineering and Technology, Taxila.\n"
                                + "Version: 1.0\n"
                                + "Contribution by: [M. Toheed Hussain]\n"
                                + "Purpose:\n[Part of 'Smart PCB Fabrication Machine' Final Year Project]\n"                            
                                + "Final Year Project Group Members:\nHamid Mehmood\n20-ENC-05\nWaqas Ahmed\n20-ENC-10\nM. Toheed Hussain\n20-ENC-46\nAmir Khan\n20-ENC-51\n"
                                + "Supervisor: Dr. Sajjad Ahmed\n";
                                


            MessageBox.Show(aboutMessage, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}
