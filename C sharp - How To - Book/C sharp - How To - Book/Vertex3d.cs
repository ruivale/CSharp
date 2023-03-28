using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CSharpHowTo_book
{
    class Vertex3d : IFormattable, IEquatable<Vertex3d>, IComparable<Vertex3d>
    {
        private double _x;
        private double _y;
        private double _z;
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }
        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public double Z
        {
            get { return _z; }
            set { _z = value; }
        }

        /*************************************************************************
        The following '?' allows this:
            Vertex3d vn = new Vertex3d(1, 2, 3);
            vn.Id = 3;      //ok
            vn.Id = null;   //ok
        /**/
        private int? _id;
        public int? Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Vertex3d(double x, double y, double z)
        {
            this._x = x;
            this._y = y;
            this._z = z;

            this._id = 0;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            //”G” is .Net’s standard for general formatting--all
            //types should support it
            if (format == null) format = "G";
            // is the user providing their own format provider?
            if (formatProvider != null)
            {
                ICustomFormatter formatter =
                formatProvider.GetFormat(this.GetType())
                as ICustomFormatter;
                if (formatter != null)
                {
                    return formatter.Format(format, this, formatProvider);
                }
            }
            //formatting is up to us, so let’s do it
            if (format == "G")
            {
                return string.Format("({0}, {1}, {2})", X, Y, Z);
            }
            StringBuilder sb = new StringBuilder();
            int sourceIndex = 0;
            while (sourceIndex < format.Length)
            {
                switch (format[sourceIndex])
                {
                    case 'X':
                        sb.Append(X.ToString());
                        break;
                    case 'Y':
                        sb.Append(Y.ToString());
                        break;
                    case 'Z':
                        sb.Append(Z.ToString());
                        break;
                    default:
                        sb.Append(format[sourceIndex]);
                        break;
                }
                sourceIndex++;
            }
            return sb.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Vertex3d)obj);
        }

        public bool Equals(Vertex3d other)
        {
            /* If Vertex3d were a reference type you would also need:
            * if ((object)other == null)
            *  return false;
            *
            * if (!base.Equals(other))
            *  return false;
            */
            return this._x == other._x
            && this._y == other._y
            && this._z == other._z;
        }
        public override int GetHashCode()
        {
            //note: This is just a sample hash algorithm.
            //picking a good algorithm can require some 
            //research and experimentation
            return (((int)_x ^ (int)_z) << 16) | (((int)_y ^ (int)_z) & 0x0000FFFF);
        }

        public int CompareTo(Vertex3d other)
        {
            if (_id < other._id)
                return -1;
            if (_id == other._id)
                return 0;
            return 1;
            /* We could also just do this:
            * return _id.CompareTo(other._id);
            * */
        }

        void WatchObject(object obj)
        {
            INotifyPropertyChanged watchableObj = obj as INotifyPropertyChanged;
            if (watchableObj != null)
            {
                watchableObj.PropertyChanged += new
                PropertyChangedEventHandler(data_PropertyChanged);
            }
        }
        void data_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //do something when data changes
        }



        /*****************************************************************************
        Solution: Operator overloading is like sugar: a little is sweet, but a lot will 
        make you sick. Ensure that you only use this technique for situations that make 
        sense.
        Implement operator +
        Notice that the method is public static and takes both operators as argum
        The same can be applied to: -, *, /, %, &, |, <<, >>, !, ~, ++, and -- operators.
        /**/
        public static Vertex3d operator +(Vertex3d a, Vertex3d b)
        {
            return new Vertex3d(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        /*******************************************************************************
        Implement operator == and operator !=
        These should always be implemented as a pair. Because we’ve already implemented a
        useful Equals() method, just call that instead.
        /**/
        public static bool operator ==(Vertex3d a, Vertex3d b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Vertex3d a, Vertex3d b)
        {
            return !(a == b);
        }

        /*************************************************************************************
        What if the type is a reference type? In this case, you have to handle null values for
        both a and b, as in this example:
        /**/
        public static bool operator ==(CatalogItem a, CatalogItem b)
        {
            if ((object)a == null && (object)b == null)
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }
        public static bool operator !=(CatalogItem a, CatalogItem b)
        {
            return !(a == b);
        }
    }
}
