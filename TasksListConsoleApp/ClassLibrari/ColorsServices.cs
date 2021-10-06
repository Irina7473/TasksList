using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClassLibrari
{
    public class ColorsServices
    {
        public ColorsServices() { }
        public ColorsServices(int id, Color name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public Color Name { get; set; }        
    }
}

/*
   private void GetColorId()
        {
            ColorCollection.Add(new ColorsServices(0, System.Drawing.Color.Gray));
            ColorCollection.Add(new ColorsServices(1, System.Drawing.Color.Yellow));
            ColorCollection.Add(new ColorsServices(2, System.Drawing.Color.Green));
            ColorCollection.Add(new ColorsServices(3, System.Drawing.Color.Gray));
            ColorCollection.Add(new ColorsServices(4, System.Drawing.Color.PaleGreen));
            ColorCollection.Add(new ColorsServices(5, System.Drawing.Color.Violet));
            ColorCollection.Add(new ColorsServices(6, System.Drawing.Color.CadetBlue));
        }
        private ObservableCollection<ColorsServices> ColorCollection = new ObservableCollection<ColorsServices>();
                
        public class ColorsServices
        {
            public ColorsServices(int id, System.Drawing.Color name)
            {
                Id = id;
                Name = name;
            }
            public int Id { get; set; }
            public System.Drawing.Color Name { get; set; }
        }

        public ObservableCollection<ColorsServices> ColorList
        {
            get { return ColorCollection; }
            set { ColorCollection = value; }
        }
*/

/*
  public class ComboItem
{
    public int Key {get; set;}
    public string Text {get; set;}
    public override string ToString()
    {
        return this.Text;
    }
}

public void OnFormLoad(object Sender, ...)
{
    IEnumerable<ComboItem> comboItems = CreateListComboItems();
    this.ComboBox1.Items.Clear();
    foreach (var comboitem in comboItems)
    {
        this.comboBox1.Items.Add(comboItem);
    }
 }
Подпишитесь на событие comboBox SelectedIndexChanged:

private void OnComboSelectedIndexChanged(object sender, EventArgs e)
{
    ComboItem selectedItem = (ComboItem)this.comboBox1.SelectedItem;
    ProcessSelectedKey(selectedItem.Key);
}

*/