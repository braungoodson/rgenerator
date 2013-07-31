using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Xml.Linq;

namespace RandomGeneration
{
    public class Generator
    {
        Random r;
        StringBuilder b;
        string[] symbols;
        public Generator()
        {
            this.r = new Random();
            this.b = new StringBuilder();
            this.symbols = new string[16];
        }
        public string Symbol()
        {
            this.b = new StringBuilder();
            this.symbols = new string[16];
            this.symbols[0] = "/";
            this.symbols[1] = "w/";
            this.symbols[2] = this.Number(1, 9) + "\"";
            this.symbols[3] = "-";
            this.symbols[4] = this.Number(0, 9) + "." + this.Number(0, 9) + "-" + this.CapitolWords(1);
            this.symbols[5] = "(" + this.CapitolLetters(this.Number(1, 9)) + ")";
            this.symbols[6] = "(" + this.CapitolWords(1) + ")";
            this.symbols[7] = this.CapitolLetters(this.Number(3, 6)) + "-" + this.Number(3, 6);
            this.symbols[8] = "";
            this.symbols[9] = "";
            this.symbols[10] = "";
            this.symbols[11] = "";
            this.symbols[12] = "";
            this.symbols[13] = "";
            this.symbols[14] = "";
            this.symbols[15] = "";

            return this.symbols[this.Number(0, 15)];
        }
        public int Number(int x, int y)
        {

            return r.Next(x, y);
        }
        public string CapitolLetters(int n)
        {
            this.b.Clear();
            char c;
            string s;
            for (int i = 0; i < n; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * this.r.NextDouble() + 65)));
                this.b.Append(c);

            }
            return s = b.ToString().ToUpper();
        }
        public string LowercaseLetters(int n)
        {
            this.b.Clear();
            char c;
            string s;
            for (int i = 0; i < n; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * this.r.NextDouble() + 65)));
                this.b.Append(c);

            }
            return s = b.ToString().ToLower();
        }
        public string CapitolWords(int n)
        {
            string s = "";
            for (int i = 0; i < n; i++)
            {
                s += this.CapitolLetters(1) + this.LowercaseLetters(this.Number(2, 10));
                if (i != n - 1) s += " ";

            }
            return s;
        }
        public string LowercaseWords(int n)
        {
            string s = "";
            for (int i = 0; i < n; i++)
            {
                s += this.LowercaseLetters(this.Number(2, 11));
                if (i != n - 1) s += " ";

            }
            return s;
        }
        public string BrandName()
        {
            return this.CapitolWords(1);
        }
        public string Name(int l)
        {
            string s = "";
            for (int i = 0; i < l; i++)
            {
                s += this.CapitolWords(1);
                if (i != l - 1) s += " ";

            }
            return s;
        }
        public string ProductName()
        {
            int x = this.Number(5, 8);
            string s = "";
            for (int i = 0; i < x; i++)
            {
                s += this.CapitolWords(1);
                s += " ";
                s += this.Symbol();
                if (i != x - 1) s += " ";

            }
            return s.Replace("  ", " ");
        }
        public string Spec()
        {
            int x = this.Number(3, 4);
            string s = "";
            for (int i = 0; i < x; i++)
            {
                s += this.CapitolWords(1);
                s += " ";
                s += this.Symbol();
                if (i != x - 1) s += " ";

            }
            return s.Replace("  ", " ");
        }
        public string ModelNumber()
        {
            int x = this.Number(2, 5);
            string s = "";
            for (int i = 0; i < x; i++)
                s += this.Number(0, 9).ToString();
            return this.CapitolLetters(this.Number(2, 4)) + s;
        }
        public int Price(int x, int y)
        {
            return this.Number(x, y);
        }
        public string Sentance()
        {
            int x = this.Number(5, 25);
            string s = this.CapitolLetters(1);
            s += this.LowercaseWords(x);
            s += ".";
            return s;
        }
        public string Overview(int x, int y)
        {
            int n = this.Number(x, y);
            string s = "";
            for (int i = 0; i < n; i++)
            {
                s += this.Sentance();
                if (i != n - 1) s += " ";
            }
            return s;
        }
        public Color aColor()
        {
            return Color.FromArgb(this.Number(0, 255), this.Number(0, 254), this.Number(0, 254));
        }
        public Bitmap Image(int x, int y)
        {
            Bitmap b = new Bitmap(x, y);
            return b;
        }
        public Bitmap BrandImage(string n, int l, int w)
        {
            //Console.WriteLine("New Brand -> {0}", n);
            Bitmap bmp = this.Image(l, w);
            Graphics g = Graphics.FromImage(bmp);
            Pen p = new Pen(System.Drawing.Brushes.Black);
            FontFamily[] f = FontFamily.Families;
            SolidBrush b;
            int x;
            do { x = this.Number(0, f.Length - 1); } while (f[x].Name == "Aharoni");
            g.DrawLine(p, new Point(50, 50), new Point(75, 75));
            string s = this.CapitolLetters(1);
            int y = this.Number(1, 4);
            Point p1 = new Point();
            if (y == 1) p1 = new Point(5, 5);
            if (y == 2) p1 = new Point(75, 5);
            if (y == 3) p1 = new Point(5, 75);
            if (y == 4) p1 = new Point(25, 5);
            g.DrawString(s, new Font("Webdings", 60), new SolidBrush(this.aColor()), p1);
            g.DrawString(n, new Font(f[x].Name, 40), new SolidBrush(this.aColor()), new Point(25, 25));
            return bmp;
        }
        struct Graph
        {
            public int[] v;
            public Point[] e;
            public Graph(int[] v, Point[] e)
            {
                this.v = v;
                this.e = e;
            }
        }
        public Bitmap ProductImage()
        {
            Bitmap b = new Bitmap(6000, 4000);
            //int v = this.Number(10, 200);
            int v = 2;
            int edges = 4;
            //Console.WriteLine("v={0}", v);
            //Graph graph = new Graph(new int[v], new Point[this.Number(v - 1, (v * (v - 1)) / 2)]);
            Graph graph = new Graph(new int[v], new Point[this.Number(v, edges)]);
            //Console.WriteLine("g.v.Length={0},g.e.Length={1}", graph.v.Length, graph.e.Length);
            //instantiate vertices
            for (int i = 0; i < v; i++)
                graph.v[i] = i;

            int x, y;
            //Generator connections for edges
            for (int i = 0; i < graph.e.Length; i++)
            {
                do { x = this.Number(0, graph.v.Length); y = this.Number(0, graph.v.Length); } while (x == y);
                graph.e[i] = new Point(x, y);
                Console.WriteLine("({0},{1})+", x, y);
                System.Threading.Thread.Sleep(10);
            }

            Point[] c = new Point[graph.v.Length];

            //Generator coordinates for nodes
            x = 0;
            y = 0;
            foreach (int u in graph.v)
            {
                //x = this.Number(0, 5920);
                //y = this.Number(0, 3920);
                c[u] = new Point(x, y);
                Console.WriteLine("p({0},{1})+{2}", c[u].X, c[u].Y, v--);
                System.Threading.Thread.Sleep(10);
            }

            Graphics g = Graphics.FromImage(b);
            //Pen p = new Pen(System.Drawing.Brushes.DarkGray);
            Pen p = new Pen(this.aColor());
            Pen p2 = new Pen(System.Drawing.Brushes.White);
            p.Width = 40;
            p2.Width = 20;
            g.FillRectangle(System.Drawing.Brushes.White, 0, 0, 6000, 4000);
            //draw connections
            int j = this.Number(1, 10);
            if (j > 5)
            {
                foreach (Point e in graph.e)
                {
                    p = new Pen(this.aColor());
                    p.Width = 40;
                    //g.DrawString(p.Color.ToString(), new Font("Arial", 20), System.Drawing.Brushes.Black, new Point(25, 0));
                    g.DrawLine(p, c[e.X].X + 40, c[e.X].Y + 40, c[e.Y].X + 40, c[e.Y].Y + 40);
                    g.DrawLine(p2, c[e.X].X + 40, c[e.X].Y + 40, c[e.Y].X + 40, c[e.Y].Y + 40);
                }
            }
            else
            {
                Pen p1 = new Pen(this.aColor());
                p1.Width = 40;
                foreach (Point e in graph.e)
                {
                    g.DrawLine(p1, c[e.X].X + 40, c[e.X].Y + 40, c[e.Y].X + 40, c[e.Y].Y + 40);
                    g.DrawLine(p2, c[e.X].X + 40, c[e.X].Y + 40, c[e.Y].X + 40, c[e.Y].Y + 40);
                }
            }
            //draw nodes
            foreach (Point r in c)
            {
                SolidBrush sb = new SolidBrush(this.aColor());
                //g.FillEllipse(sb, r.X, r.Y, 80, 80);
                g.FillEllipse(System.Drawing.Brushes.White, r.X + 20, r.Y + 20, 40, 40);
            }

            //g.DrawString(j.ToString(), new Font("Arial", 20), System.Drawing.Brushes.Black, new Point(0, 0));
            //Console.WriteLine("\nNew Image!\n");

            return b;
        }
        public XElement QuickInfo(string bn)
        {
            XElement x = new XElement("info");
            XElement w = new XElement("warranty", "Limited Warranty: "+this.Number(1,3)+" year(s).");
            XElement c = new XElement("contact",
                new XAttribute("site", bn),
                new XAttribute("phone", "1-"+this.Number(100,999)+"-"+this.Number(100,999)+"-"+this.Number(1000,9999))
                );
            XElement r = new XElement("return");
            x.Add(w);
            x.Add(c);
            x.Add(r);
            string rp;
            rp = this.Sentance();
            rp += this.Sentance();
            rp += this.Sentance();
            r.Add(new XText(rp));
            //Warranty;
            //Website:
            //Support Phone:
            //Return Policy
            return x;
        }
        public XElement ProductDetails(string b, string m)
        {
            XElement x = new XElement("details");
            XElement model = new XElement("model", new XAttribute("brand", b), new XAttribute("model", m));
            x.Add(model);
            int n = this.Number(2, 6);
            for (int i = 0; i <= n; i++)
            {
                int j = this.Number(2, 8);
                XElement t = new XElement("d_block", new XAttribute("d_title", this.CapitolWords(1)));
                for (int k = 0; k <= j; k++)
                {
                    XElement r = new XElement("detail",
                        new XElement("d", this.CapitolWords(this.Number(1, 2))),
                        new XElement("e", this.ProductName())
                    );
                    t.Add(r);
                    System.Threading.Thread.Sleep(10);
                }
                x.Add(t);
                System.Threading.Thread.Sleep(10);
            }
            return x;
        }
        public XElement ShortSpecs()
        {
            XElement x = new XElement("specs");
            XElement s = new XElement("spec", this.Spec());
            x.Add(s);
            s = new XElement("spec", this.Spec());
            x.Add(s);
            s = new XElement("spec", this.Spec());
            x.Add(s);
            return x;
        }
    }
}

