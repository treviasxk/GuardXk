using System;
using System.Security.Cryptography;
using System.Text;

namespace GuardXk.Security{
    public class Cryptography{
        Aes AES;
        byte[] privateKeyAES;
        public Cryptography(){
            privateKeyAES = GetHashMD5(Encoding.ASCII.GetBytes("ChecksumHere"));
            AES ??= Aes.Create();
        }

        public byte[] EncryptAES(string value){
            return EncryptAES(Encoding.UTF8.GetBytes(value));
        }

        public string DecryptStringAES(byte[] bytes){
            return bytes.Length == 0 ? "" : Encoding.UTF8.GetString(DecryptAES(bytes));
        }

        public byte[] EncryptAES(int value){
            return EncryptAES(BitConverter.GetBytes(value));
        }

        public int DecryptIntAES(byte[] bytes){
            return bytes.Length == 0 ? 0 : BitConverter.ToInt32(DecryptAES(bytes));
        }

        public byte[] EncryptAES(float value){
            return EncryptAES(BitConverter.GetBytes(value));
        }

        public float DecryptFloatAES(byte[] bytes){
            return bytes.Length == 0 ? 0 : BitConverter.ToSingle(DecryptAES(bytes));
        }

        public byte[] EncryptAES(byte[] _byte){
            try{
                using var encryptor = AES.CreateEncryptor(privateKeyAES, privateKeyAES);
                return encryptor.TransformFinalBlock(_byte, 0, _byte.Length);
            }
            catch{
                return new byte[]{};
            }
        }
        
        public byte[] DecryptAES(byte[] _byte){
            try{
                using var encryptor = AES.CreateDecryptor(privateKeyAES, privateKeyAES);
                return encryptor.TransformFinalBlock(_byte, 0, _byte.Length);
            }
            catch{
                return new byte[]{};
            }
        }

        public byte[] GetHashMD5(byte[] _byte){
            try{
                MD5 md5 = MD5.Create();
                return md5.ComputeHash(_byte);
            }catch{
                return new byte[]{};
            }
        }
    }
}