using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adamasmaca
{
     class Kelimeler
    {
        int harfsayisi;
        Random rnd = new Random();
        string yol = "kelimeler.txt";
        StreamReader str;
        ArrayList kelime_listesi = new ArrayList();



        public Kelimeler(int harfsayisi)
        {
            this.harfsayisi = harfsayisi;
        }

        public void kelimeleri_Cek()
        {
            string yeni_kelime;
            str = new StreamReader(yol);
            while (!string.IsNullOrWhiteSpace(yeni_kelime=str.ReadLine()))
            {
                if (yeni_kelime.Trim().Length==harfsayisi)
                {
                    kelime_listesi.Add(yeni_kelime.Trim());
                }
            }
        }

        public string random_kelime_Cek()
        {
            kelimeleri_Cek();
            int index;
            index = rnd.Next(0, kelime_listesi.Count);
            return kelime_listesi[index].ToString();
        }


    }
}
