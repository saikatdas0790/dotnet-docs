using System;
using System.Text;

namespace tour_of_dotnet
{
    class Program
    {
        public int Length { get; set; }
        public string TempString { get; set; }

        static void Main(string[] args)
        {
            string tempString = "Hello World!";
            //string tempString = Console.ReadLine();

            Program temp = new Program() { TempString = "Hello World!" };

            new Program().Length = tempString.Length;
        }

        public override string ToString()
        {
            if (Length == 0)
                return String.Empty;

            string ret = string.FastAllocateString(Length);
            StringBuilder chunk = new StringBuilder(TempString);
            unsafe
            {
                fixed (char* destinationPtr = ret)
                {
                    do
                    {
                        if (chunk.m_ChunkLength)
                        {

                        }
                    } while (chunk != null);
                }
            }
        }
    }




}
