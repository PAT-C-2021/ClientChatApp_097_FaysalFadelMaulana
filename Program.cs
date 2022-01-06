using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WCFService_2Way_20190140097;

namespace ClientChatApp_20190140097_FaysalFM
{
    class Program
    {
        public class ClientCallBack : ServiceReference1.IServiceCallBackCallback
        {
            public void pesanKirim(string user, string pesan)
            {
                Console.WriteLine("{0}: {1}", user, pesan);
            }

        }

        static void Main(string[] args)
        {
            InstanceContext context = new InstanceContext(new ClientCallBack());
            ServiceReference1.ServiceCallBackClient server = new ServiceReference1.ServiceCallBackClient(context);

            Console.WriteLine("Masukkan Username : ");
            string nama = Console.ReadLine();
            server.gabung(nama);

            Console.WriteLine("Kirim Pesan : ");
            string pesan = Console.ReadLine();

            while (true)
            {
                if (!string.IsNullOrEmpty(pesan))
                    server.kirimPesan(pesan);
                Console.WriteLine("Kirim Pesan : "+"\n");
                pesan = Console.ReadLine();
            }
        }
    }
}
