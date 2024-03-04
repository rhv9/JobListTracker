using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListTracker.MVVM.Model
{
    public class PDFUtil
    {
        // I was going to compare the pdf files byte by byte but then had an epiphany. 
        // More likely than not, if a pdf file is different, they have different length.
        // The chances that two pdfs are different but have same sizes must be impossible.
        // And in my case, it is only differentiating CVs I have edited.
        public static bool isEqualPDF(string first_filepath, string second_filepath)
        {
            try
            {
                using (FileStream first_fs = new FileStream(first_filepath, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream second_fs = new FileStream(second_filepath, FileMode.Open, FileAccess.Read))
                    {
                        if (first_fs.Length == second_fs.Length)
                            return true;
                    }
                }
            } catch(FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
    }
}
