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
        public string input;           
        public CaptureDeviceList devices;  
        public ICaptureDevice selected;
        public String source;              
        public string Time;                
        public String destination;         
        public string protocol;            
        public String length;              
        public String type;                
        public string info;
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
            {MessageBox.Show(ex.ToString());}
        }
        private void selected_OnPacketArrival(object sender, CaptureEventArgs e)
        {

            Packet pack = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            type = pack.GetType().ToString();
            String y = pack.ToString();
            Console.WriteLine(y);
            if (pack != null)
            {
             int counter = 0;
             string temp = " ";
             int alert1 = 0;
             int alert2 = 0;
             int alert3 = 0;
             for (int i = 0; i < y.Length - 1; i++)
                 {
                 if (y[i] == '=' | counter == 4 | counter == 5 | counter == 7)
                    {
                     if (counter == 4 && alert == 0)
                        {
                         if (y[i + 1] != ',') { temp = temp + y[i]; }
                         else
                            {
                             temp = temp + y[i];
                             source = temp;
                             temp = " ";
                             alert1 = 1;
                            }
                        }
                     else if (counter == 5 && alert2 == 0)
                             {
                              if (y[i + 1] != ',') {temp = temp + y[i];}
                              else
                              {
                               temp = temp + y[i];
                               destination = temp;
                               temp = " ";
                               alert2 = 1;
                              }
                            }
                     else if (counter == 7 && alert3 == 0)
                            {
                             if (y[i + 1] != ',') {temp = temp + y[i];}
                             else
                             {
                              temp = temp + y[i];
                              protocol = temp;
                              temp = " ";
                              alert3 = 1;
                             }
                            }
                        else if (y[i] == '=') {counter++;}
                    }
                }
                int len = e.Packet.Data.Length;
                length = len.ToString();
                info = pack.ToString();
                DateTime time = e.Packet.Timeval.Date;
                Time = time.Hour.ToString() + " : " + time.Minute.ToString() + " : " + time.Second.ToString() + " : " + time.Millisecond.ToString();
                if (dataGridView1.InvokeRequired)
                {
                    dataGridView1.Invoke((MethodInvoker)delegate ()
                    {
                        dataGridView1.Rows.Add(Time,source,destination,protocol,length,info);
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
             {MessageBox.Show(ex.ToString());}
        }
         void show_all_Adapters()
         {
             devices = CaptureDeviceList.Instance;
             foreach (var dev in devices)
             {
              listView1.Items.Add(dev.Description);
             }
         }
    } 
 }
    
