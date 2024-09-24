using System.Collections.Concurrent;
using System.Threading.Tasks;
using GuardXk.Security;

namespace GuardXk{
    public class GXK{
        static Cryptography Cryptography {get;}
        internal static ConcurrentQueue<VariableGXK> Values;
        static GXK(){
            Cryptography = new Cryptography();
            Values = new ConcurrentQueue<VariableGXK>();
        }

        public class Int : VariableGXK{
            public int Value {get{return Cryptography.DecryptIntAES(bytes);} set{bytes = Cryptography.EncryptAES(value);}}
            public Int(int value = 0){
                bytes = Cryptography.EncryptAES(value);
            }
        }

        public class Float : VariableGXK{
            public float Value {get{return Cryptography.DecryptFloatAES(bytes);} set{bytes = Cryptography.EncryptAES(value);}}
            public Float(float value = 0){
                bytes = Cryptography.EncryptAES(value);
            }
        }

        public class String : VariableGXK{
            public string Value {get{return Cryptography.DecryptStringAES(bytes);} set{bytes = Cryptography.EncryptAES(value);}}
            public String(string value = ""){
                bytes = Cryptography.EncryptAES(value);
            }
        }

        public static void Dispose(){
            Parallel.Invoke(()=>{
                while(Values.Count > 0)
                if(Values.TryDequeue(out VariableGXK result))
                    result.Dispose();
            });
        }
    }
}