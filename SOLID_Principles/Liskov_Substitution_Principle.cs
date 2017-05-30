using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principles
{
    public class Liskov_Substitution_Principle
    {
        #region Implementation without LSP 

        //public class SqlFile
        //{
        //    public string FilePath { get; set; }
        //    public string FileText { get; set; }
        //    public string LoadText()
        //    {
        //        return string.Empty;
        //    }
        //    public string SaveText()
        //    {
        //        return string.Empty;
        //    }
        //}
        //public class SqlFileManager
        //{
        //    public List<SqlFile> lstSqlFiles { get; set; }

        //    public string GetTextFromFiles()
        //    {
        //        StringBuilder objStrBuilder = new StringBuilder();
        //        foreach (var objFile in lstSqlFiles)
        //        {
        //            objStrBuilder.Append(objFile.LoadText());
        //        }
        //        return objStrBuilder.ToString();
        //    }
        //    public void SaveTextIntoFiles()
        //    {
        //        foreach (var objFile in lstSqlFiles)
        //        {
        //            objFile.SaveText();
        //        }
        //    }
        //}

        //-----Now if we have to add additional functionality of checking for readonly files-----

        //public class SqlFile
        //{
        //    public string LoadText()
        //    {
        //        return string.Empty;
        //    }
        //    public void SaveText()
        //    {
        //        /* Code to save text into sql file */
        //    }
        //}
        //public class ReadOnlySqlFile : SqlFile
        //{
        //    public string FilePath { get; set; }
        //    public string FileText { get; set; }
        //    public string LoadText()
        //    {
        //        return string.Empty;
        //    }
        //    public void SaveText()
        //    {
        //        /* Throw an exception when app flow tries to do save. */
        //        throw new IOException("Can't Save");
        //    }
        //}

        //public class SqlFileManager
        //{
        //    public List<SqlFile> lstSqlFiles { get; set; }
        //    public string GetTextFromFiles()
        //    {
        //        StringBuilder objStrBuilder = new StringBuilder();
        //        foreach (var objFile in lstSqlFiles)
        //        {
        //            objStrBuilder.Append(objFile.LoadText());
        //        }
        //        return objStrBuilder.ToString();
        //    }
        //    public void SaveTextIntoFiles()
        //    {
        //        foreach (var objFile in lstSqlFiles)
        //        {
        //            //Check whether the current file object is read only or not.If yes, skip calling it's  
        //            // SaveText() method to skip the exception.  

        //            if (objFile is ReadOnlySqlFile)
        //                objFile.SaveText();
        //        }
        //    }
        //}

        #endregion

        #region Implementation with LSP

        public interface IReadableSqlFile
        {
            string LoadText();
        }
        public interface IWritableSqlFile
        {
            void SaveText();
        }

        public class ReadOnlySqlFile : IReadableSqlFile
        {
            public string FilePath { get; set; }
            public string FileText { get; set; }
            public string LoadText()
            {
                return string.Empty;
            }
        }  

        public class SqlFile : IWritableSqlFile, IReadableSqlFile
        {
            public string FilePath { get; set; }
            public string FileText { get; set; }
            public string LoadText()
            {
                return string.Empty;
            }
            public void SaveText()
            {
                /* Code to save text into sql file */
            }

            public class SqlFileManager
            {
                public string GetTextFromFiles(List<IReadableSqlFile> aLstReadableFiles)
                {
                    StringBuilder objStrBuilder = new StringBuilder();
                    foreach (var objFile in aLstReadableFiles)
                    {
                        objStrBuilder.Append(objFile.LoadText());
                    }
                    return objStrBuilder.ToString();
                }
                public void SaveTextIntoFiles(List<IWritableSqlFile> aLstWritableFiles)
                {
                    foreach (var objFile in aLstWritableFiles)
                    {
                        objFile.SaveText();
                    }
                }
            }   
        } 

        #endregion
    }
}
