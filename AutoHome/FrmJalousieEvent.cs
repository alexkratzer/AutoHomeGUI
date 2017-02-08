using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cpsLIB; //frames

namespace AutoHome
{
    public partial class FrmJalousieEvent : Form
    {
        List<UC_jalousieEvent> list_UC_jalousie = new List<UC_jalousieEvent>();
        aktuator _a;
        public FrmJalousieEvent(object a)
        {
            InitializeComponent();
            _a = (aktuator)a;
            init();
            this.Text = "Jalousie: " + _a.Name;
        }

        private void init() {
            for (int i = 0; i < 10; i++)
            {
                list_UC_jalousie.Add(new UC_jalousieEvent(_a, Convert.ToInt16(i)));
                list_UC_jalousie[i].Location = new Point(10, i * 60);
                this.Controls.Add(list_UC_jalousie[i]);
            }
        }

        public void print_data(object _f) {
            Frame f = (Frame)_f;
            list_UC_jalousie[f.getPayload(2)].print_data(f);
        
        }
    }
}
