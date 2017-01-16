using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Koszule
    {

        private KoszuleKoszula[] koszulaField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Koszula")]
        public KoszuleKoszula[] Koszula
        {
            get
            {
                return this.koszulaField;
            }
            set
            {
                this.koszulaField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class KoszuleKoszula
    {

        private string nazwaField;

        private string producentField;

        private string skladField;

        private string plecField;

        private string kategoriaField;

        private KoszuleKoszulaProdukty[] produktField;

        /// <remarks/>
        public string Nazwa
        {
            get
            {
                return this.nazwaField;
            }
            set
            {
                this.nazwaField = value;
            }
        }

        /// <remarks/>
        public string Producent
        {
            get
            {
                return this.producentField;
            }
            set
            {
                this.producentField = value;
            }
        }

        /// <remarks/>
        public string Sklad
        {
            get
            {
                return this.skladField;
            }
            set
            {
                this.skladField = value;
            }
        }

        /// <remarks/>
        public string Plec
        {
            get
            {
                return this.plecField;
            }
            set
            {
                this.plecField = value;
            }
        }

        /// <remarks/>
        public string Kategoria
        {
            get
            {
                return this.kategoriaField;
            }
            set
            {
                this.kategoriaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Produkty", IsNullable = false)]
        public KoszuleKoszulaProdukty[] Produkt
        {
            get
            {
                return this.produktField;
            }
            set
            {
                this.produktField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class KoszuleKoszulaProdukty
    {

        private string kolorField;

        private string zdjecieField;

        private ushort cenaField;

        private string opisField;

        private ushort iloscField;

        private byte kolnierzykField;

        private byte ramionaField;

        private byte rekawField;

        private byte dlugoscKoszuliField;

        private byte taliaField;

        private byte klatkaField;

        private byte mankietField;

        /// <remarks/>
        public string Kolor
        {
            get
            {
                return this.kolorField;
            }
            set
            {
                this.kolorField = value;
            }
        }

        /// <remarks/>
        public string Zdjecie
        {
            get
            {
                return this.zdjecieField;
            }
            set
            {
                this.zdjecieField = value;
            }
        }

        /// <remarks/>
        public ushort Cena
        {
            get
            {
                return this.cenaField;
            }
            set
            {
                this.cenaField = value;
            }
        }

        /// <remarks/>
        public string Opis
        {
            get
            {
                return this.opisField;
            }
            set
            {
                this.opisField = value;
            }
        }

        /// <remarks/>
        public ushort Ilosc
        {
            get
            {
                return this.iloscField;
            }
            set
            {
                this.iloscField = value;
            }
        }

        /// <remarks/>
        public byte Kolnierzyk
        {
            get
            {
                return this.kolnierzykField;
            }
            set
            {
                this.kolnierzykField = value;
            }
        }

        /// <remarks/>
        public byte Ramiona
        {
            get
            {
                return this.ramionaField;
            }
            set
            {
                this.ramionaField = value;
            }
        }

        /// <remarks/>
        public byte Rekaw
        {
            get
            {
                return this.rekawField;
            }
            set
            {
                this.rekawField = value;
            }
        }

        /// <remarks/>
        public byte DlugoscKoszuli
        {
            get
            {
                return this.dlugoscKoszuliField;
            }
            set
            {
                this.dlugoscKoszuliField = value;
            }
        }

        /// <remarks/>
        public byte Talia
        {
            get
            {
                return this.taliaField;
            }
            set
            {
                this.taliaField = value;
            }
        }

        /// <remarks/>
        public byte Klatka
        {
            get
            {
                return this.klatkaField;
            }
            set
            {
                this.klatkaField = value;
            }
        }

        /// <remarks/>
        public byte Mankiet
        {
            get
            {
                return this.mankietField;
            }
            set
            {
                this.mankietField = value;
            }
        }
    }
}
