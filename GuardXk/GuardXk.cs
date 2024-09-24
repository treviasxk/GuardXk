using System;
using System.Collections.Concurrent;
using System.Text;
using GuardXk.Encrypt;

namespace GuardXk{
    public static class GXK{
        internal struct Data {
            public byte[] bytes;
        }
        static ConcurrentDictionary<int, Data> values;
        static Encrypts encrypts;
        static int instances;

        public class Int{
            public int Value {get{return GetInt(id);} set{SetInt(value, id);}}
            public int id {get;}
            public Int(int value = 0){
                id = SetInt(value);
            }
        }

        public class String{
            public string Value {get{return GetString(id);} set{SetString(value, id);}}
            public int id {get;}
            public String(string value = ""){
                id = SetString(value);
            }
        }

        static GXK(){
            values = new ConcurrentDictionary<int, Data>();
            encrypts = new Encrypts();
        }

        static int SetString(string value, int id = 0){
            var key = id != 0 ? id : instances++;
            if(!values.ContainsKey(key)){
                values.TryAdd(key, new Data(){bytes = encrypts.EncryptAES(Encoding.UTF8.GetBytes(value))});
            }else{
                values[key] = new Data(){bytes  = encrypts.EncryptAES(Encoding.UTF8.GetBytes(value))};
            }
            return key;
        }

        static string GetString(int key){
            return Encoding.UTF8.GetString(encrypts.DecryptAES(values[key].bytes));
        }

        static int SetInt(int value, int id = 0){
            var key = id != 0 ? id : instances++;
            if(!values.ContainsKey(key)){
                values.TryAdd(key, new Data(){bytes = encrypts.EncryptAES(BitConverter.GetBytes(value))});
            }else{
                values[key] = new Data(){bytes  = encrypts.EncryptAES(BitConverter.GetBytes(value))};
            }
            return key;
        }

        public static int GetInt(int key){
            return BitConverter.ToInt32(encrypts.DecryptAES(values[key].bytes));
        }
    }
}