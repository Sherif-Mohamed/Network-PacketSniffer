using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpPcap;
using PacketDotNet;
using System.Windows.Forms;
using SharpPcap.WinPcap;
using System.Net;

namespace Packet_Sniffer_test
{
    public partial class GUI : Form
     {
        public string uy;           // Array of devices
        CaptureDeviceList devices;  //Global selected device
        ICaptureDevice selected;
        int packet_number = 0;      //counter to count packet
        String source;              //source ip
        string Number;              //counter number but in string(convert packet_number to string)
        string Time;                //string to time
        String destination;         //destination ip
        string protocol;            //string for protocol type
        String length;              //string for packet length
        String type;                //type of packet(ethernet...)
        public string info;         //string contains all packet information
        public GUI()
         {
             InitializeComponent();
             show_all_Adapters();
             Select_but.Click += Button1_Click;
             button2.Click += on_start_scan;
             button3.Click += on_stop_event;
         }

         private void on_stop_event(object sender, EventArgs e)
         {
             selected.StopCapture();
             selected.Close();
         }

         private void on_start_scan(object sender, EventArgs e)
         {
            try
            {
                selected.OnPacketArrival += selected_OnPacketArrival;
                selected.Open(DeviceMode.Promiscuous, 100);
                selected.StartCapture();
            }
            catch (Exception ex)
            {MessageBox.Show("Make sure you already selected a valid device\n\n" + ex.ToString());}
        }
        private void selected_OnPacketArrival(object sender, CaptureEventArgs e)
        {

            Packet p = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            type = p.GetType().ToString();
            String y = p.ToString();
            Console.WriteLine(y);
            if (p != null)
            {
             int counter = 0;
             string temp = " ";
             int flag1 = 0;
             int flag2 = 0;
             int flag3 = 0;
             for (int i = 0; i < y.Length - 1; i++)
                 {
                 if (y[i] == '=' | counter == 4 | counter == 5 | counter == 7)
                    {
                     if (counter == 4 && flag1 == 0)
                        {
                         if (y[i + 1] != ',') { temp = temp + y[i]; }
                         else
                            {
                             temp = temp + y[i];
                             source = temp;
                             temp = " ";
                             flag1 = 1;
                            }
                        }
                     else if (counter == 5 && flag2 == 0)
                             {
                              if (y[i + 1] != ',') {temp = temp + y[i];}
                              else
                              {
                               temp = temp + y[i];
                               destination = temp;
                               temp = " ";
                               flag2 = 1;
                              }
                            }
                     else if (counter == 7 && flag3 == 0)
                            {
                             if (y[i + 1] != ',') {temp = temp + y[i];}
                             else
                             {
                              temp = temp + y[i];
                              protocol = temp;
                              temp = " ";
                              flag3 = 1;
                             }
                            }
                        else if (y[i] == '=') {counter++;}
                    }
                }


                int len = e.Packet.Data.Length;
                length = len.ToString();
                info = p.ToString();
                DateTime time = e.Packet.Timeval.Date;
                Number = packet_number.ToString();
                Time = time.Hour.ToString() + " : " + time.Minute.ToString() + " : " + time.Second.ToString() + " : " + time.Millisecond.ToString();

                packet_number++;

                if (dataGridView1.InvokeRequired)
                {
                    dataGridView1.Invoke((MethodInvoker)delegate ()
                    {
                        dataGridView1.Rows.Add(Number,Time,source,destination,protocol,length,info);
                    });
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
         {
            try
             {
                 selected = devices[listView1.SelectedIndices[0]];
                 button2.Enabled = true;
            }
            catch (Exception ex)
             {MessageBox.Show("Make sure you already selected a valid device\n\n" + ex.ToString());}
        }

         void show_all_Adapters()
         {
             devices = CaptureDeviceList.Instance;
             foreach (var dev in devices)
             {
              listView1.Items.Add(dev.Description);
             }
         }

        private void Select_but_Click(object sender, EventArgs e)
        {

        }

        private void GUI_Load(object sender, EventArgs e)
        {
        
        }
    } 
 }
    
