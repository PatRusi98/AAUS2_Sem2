using System.Text;
using AAUS2_HeapFile.Interfaces;

namespace AAUS2_HeapFile.Entities
{
    public class ServiceRecord : IRecord<ServiceRecord>
    {
        private const int _descriptionLength = 20;
        private string _description;

        public DateTime Date { get; set; }
        public double Price { get; set; }
        public string Description
        {
            get => _description.PadRight(_descriptionLength, '\0');
            set => _description = value.Length > _descriptionLength
                ? value.Substring(0, _descriptionLength)
                : value.PadRight(_descriptionLength, '\0');
        }

        public ServiceRecord()
        {
            Date = DateTime.MinValue;
            Price = -1;
            Description = string.Empty.PadRight(_descriptionLength, '\0');
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

            Description = Encoding.UTF8.GetString(byteArray, index, _descriptionLength).TrimEnd('\0');
        }

        public int GetSize()
        {
            int dateSize = sizeof(long);
            int priceSize = sizeof(double);
            int descriptionSize = _descriptionLength;

            return dateSize + priceSize + descriptionSize;
        }

        public byte[] ToByteArray()
        {
            var dateBytes = BitConverter.GetBytes(Date.Ticks);
            var priceBytes = BitConverter.GetBytes(Price);
            var descriptionBytes = Encoding.UTF8.GetBytes(Description);

            var result = new byte[dateBytes.Length + priceBytes.Length + descriptionBytes.Length];
            int offset = 0;

            Buffer.BlockCopy(dateBytes, 0, result, offset, dateBytes.Length);
            offset += dateBytes.Length;

            Buffer.BlockCopy(priceBytes, 0, result, offset, priceBytes.Length);
            offset += priceBytes.Length;

            Buffer.BlockCopy(descriptionBytes, 0, result, offset, descriptionBytes.Length);

            return result;
        }
    }
}
