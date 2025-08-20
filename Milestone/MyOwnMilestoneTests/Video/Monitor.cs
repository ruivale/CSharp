using System;
using VideoOS.Platform;


namespace MyOwnMilestoneTests.Video
{

    /// <summary>
    /// Class to represent a monitor in the Milestone system.
    /// 
    /// It also allows for quick retrieval of a monitor's instance from its FQID.
    /// </summary>
    public class Monitor
    {
        private readonly string _strName;
        private readonly string _strObjId;
        private readonly FQID _fqid;

        /// <summary>
        /// The monitor's FQID.
        /// </summary>
        public FQID FQID
        {
            get { return _fqid; }
        }

        /// <summary>
        /// The monitor's FQID object id as a string.
        /// </summary>
        public string ObjId
        {
            get { return _strObjId; }
        }

        /// <summary>
        /// The monitor's name.
        /// </summary>
        public string Name
        {
            get { return _strName; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Kind Kind
        {
            get { return (Kind)Kind.DefaultTypeToNameTable[this._fqid.Kind]; }
        }

        /// <summary>
        /// Get a monitor instance from its FQID.
        /// </summary>
        /// <param name="fqid"></param>
        public Monitor(FQID fqid, string strName)
        {
            _fqid = fqid;
            _strObjId = fqid.ObjectId.ToString();
            _strName = strName;
        }


        /// <summary>
        /// Get a monitor description.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToString(string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strIndent"></param>
        /// <returns></returns>
        public string ToString(string strIndent)
        {
            return
                $"Monitor[{strIndent}Name:{this.Name} {strIndent}FQID[" +
                    $"{strIndent}[ObjId:{this._fqid.ObjectId}]" +
                    $"{strIndent}[ParentId:{this._fqid.ParentId}]" +
                    $"{strIndent}[Kind:{this._fqid.Kind} [({Kind.DefaultTypeToNameTable[this._fqid.Kind]}) ({Kind.DefaultTypeToCategoryTable[this._fqid.Kind]})]]" +
                    $"{strIndent}[ServerId:{this._fqid.ServerId}]" +
                    $"{strIndent}[FolderType:{this._fqid.FolderType}]]]";
        }
    }
}
