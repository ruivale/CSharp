using System;
using VideoOS.Platform;



namespace MyOwnMilestoneTests.Video
{

    /// <summary>
    /// Class to represent a camera in the Milestone system.
    /// 
    /// It also allows for quick retrieval of a camera's instance from its FQID.
    /// </summary>
    public class Camera
    {


        private readonly string _strName;
        private readonly string _strObjId;
        private readonly FQID _fqid;

        /// <summary>
        /// The camera's FQID.
        /// </summary>
        public FQID FQID
        {
            get { return _fqid; }
        }

        /// <summary>
        /// The camera's FQID object id as a string.
        /// </summary>
        public string ObjId
        {
            get { return _strObjId; }
        }

        /// <summary>
        /// The camera's name.
        /// </summary>
        public string Name
        {
            get { return _strName; }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public Kind Kind
        //{
        //    get { return (Kind)Kind.DefaultTypeToNameTable[this._fqid.Kind]; }
        //}
        /// <summary>
        /// 
        /// </summary>
        public Kind Kind
        {
            get { return (Kind)Kind.DefaultTypeToNameTable[this._fqid.Kind]; }
        }



        /// <summary>
        /// Get a camera instance from its FQID.
        /// </summary>
        /// <param name="fqid"></param>
        public Camera(FQID fqid, string strName)
        {
            _fqid = fqid;
            _strObjId = fqid.ObjectId.ToString();
            _strName = strName; 
        }


        /// <summary>
        /// Get a camera description.
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
                $"Camera[{strIndent}Name:{this.Name} {strIndent}FQID[" +
                    $"{strIndent}[ObjId:{this._fqid.ObjectId}]" +
                    $"{strIndent}[ParentId:{this._fqid.ParentId}]" +
                    $"{strIndent}[Kind:({this._fqid.Kind} [{Kind.DefaultTypeToNameTable[this._fqid.Kind]}) ({Kind.DefaultTypeToCategoryTable[this._fqid.Kind]})]]" +
                    $"{strIndent}[ServerId:{this._fqid.ServerId}]" +
                    $"{strIndent}[FolderType:{this._fqid.FolderType}]]]";
        }
    }
}
