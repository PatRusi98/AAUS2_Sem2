using AAUS2_HeapFile.Interfaces;
using System.Text;

namespace AAUS2_HeapFile.Entities
{
    public class ServiceRecord : IRecord<ServiceRecord>
    {
        private const int _descriptionWordLength = 20;
        private const int _descriptionWordsCount = 10;
        private string[] _description = new string[10];
        private int[] _wordLengths = new int[10];

        public DateTime Date { get; set; }
        public double Price { get; set; }
        public string Description
        {
            get
            {
                string desc = string.Empty;

                for (int i = 0; i < _descriptionWordsCount; i++)
                {
                    desc += _description[i].Substring(0, _wordLengths[i]) + " ";
                }

                desc = desc.TrimEnd();
                return desc;
            }

            set
            {
                if (value == null)
                {
                    for (int i = 0; i < _descriptionWordsCount; i++)
                    {
                        _description[i] = string.Empty.PadRight(_descriptionWordLength, '\0');
                        _wordLengths[i] = 0;
                    }
                }
                else
                {
                    var words = value.Split(' ');
                    for (int i = 0; i < _descriptionWordsCount; i++)
                    {
                        if (i < words.Length)
                        {
                            if (words[i].Length > _descriptionWordLength)
                            {
                                _description[i] = words[i].Substring(0, _descriptionWordLength);
                                _wordLengths[i] = _descriptionWordLength;
                            }
                            else if (words[i].Length < _descriptionWordLength)
                            {
                                _description[i] = words[i].PadRight(_descriptionWordLength, '\0');
                                _wordLengths[i] = words[i].Length;
                            }
                        }
                        else
                        {
                            _description[i] = string.Empty.PadRight(_descriptionWordLength, '\0');
                            _wordLengths[i] = 0;
                        }
                    }
                
                }
            }
        }

        public ServiceRecord()
        {
            Date = DateTime.MinValue;
            Price = -1;
            Description = null;
        }

        public ServiceRecord CreateCopy()
        {
            return new ServiceRecord
            {
                Date = Date,
                Price = Price,
                Description = Description
            };
        }

        public bool Equals(ServiceRecord data)
        {
            if (data == null) return false;

            return Date.Equals(data.Date) &&
                   Price.Equals(data.Price);
        }

        public void FromByteArray(byte[] byteArray)
        {
            var index = 0;

            Date = new DateTime(BitConverter.ToInt64(byteArray, index));
            index += sizeof(long);

            Price = BitConverter.ToDouble(byteArray, index);
            index += sizeof(double);

            for (int i = 0; i < _descriptionWordsCount; i++)
            {
                _wordLengths[i] = BitConverter.ToInt32(byteArray, index);
                index += sizeof(int);

                _description[i] = Encoding.UTF8.GetString(byteArray, index, _descriptionWordLength);
                index += _descriptionWordLength;
            }
        }

        public int GetSize()
        {
            int dateSize = sizeof(long);
            int priceSize = sizeof(double);
            int descriptionSize = 2 * _descriptionWordLength * _descriptionWordsCount;
            int wordsLengthSize = sizeof(int) * _descriptionWordsCount;

            return dateSize + priceSize + descriptionSize + wordsLengthSize;
        }

        public byte[] ToByteArray()
        {
            var dateBytes = BitConverter.GetBytes(Date.Ticks);
            var priceBytes = BitConverter.GetBytes(Price);

            var descLength = (2 * _descriptionWordLength * _descriptionWordsCount) + (sizeof(int) * _descriptionWordsCount);
            var descBytes = new byte[descLength];
            int index = 0;
            int counter = 0;

            foreach (var word in _description)
            {
                var wordLengthBytes = BitConverter.GetBytes(_wordLengths[counter]);
                var wordBytes = Encoding.UTF8.GetBytes(word);

                Buffer.BlockCopy(wordLengthBytes, 0, descBytes, index, wordLengthBytes.Length);
                index += wordLengthBytes.Length;

                Buffer.BlockCopy(wordBytes, 0, descBytes, index, wordBytes.Length);
                index += wordBytes.Length;
                counter++;
            }

            var result = new byte[dateBytes.Length + priceBytes.Length + descBytes.Length];
            int offset = 0;

            Buffer.BlockCopy(dateBytes, 0, result, offset, dateBytes.Length);
            offset += dateBytes.Length;

            Buffer.BlockCopy(priceBytes, 0, result, offset, priceBytes.Length);
            offset += priceBytes.Length;

            Buffer.BlockCopy(descBytes, 0, result, offset, descBytes.Length);

            return result;
        }

        public override string ToString()
        {
            return $"\nDate: {Date}, Price: {Price}, Description: {Description}";
        }
    }
}
