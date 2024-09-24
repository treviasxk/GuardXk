using System.Security.Cryptography;
using System.Text;

namespace GuardXk.Encrypt{
    public class Encrypts{
        Aes AES;
        byte[] privateKeyAES;
        public Encrypts(){
            privateKeyAES = GetHashMD5(Encoding.ASCII.GetBytes("teste"));
            AES ??= Aes.Create();
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