using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace  Common2
{
    public class JSRSA
    {
        //private static string privateKey => @"MIICXQIBAAKBgQCa11fMnpxUQKlfF3UzmCjIyHFGO1u6qkNQ9Ij9d6prSl6nC0KX8KjipofEfUw6Ny6ggrd6f+i/OTN5ySKtNdsGaOdK5nYkRbaQEOB257kitjxCOCeJGjWL4Np4+5JGcdzSPvRnnjOGrLXN6UpXIDV8+cB/eUoZ+KO431bUSD5T0QIDAQABAoGBAJHJmXAeEqC9NPtEceQ/Kn9JQmXW85oAP1tUsjq8Veeo4Q+0aWH3hHvKQeB9/Kx/UlZsXOZo0jJhYBcViqG9KFcWDMuzKdOIfL/Eh/wNtyVoCsoJPqrpq3z7x5DHEps0FJMBzu1vYDhQwmYaerqv9hHWtcpz8PyzPQ8/TULyfsuFAkEApObPjyMOrv417UfAzaTkLQIaYU3WdwuaLmp2ZvTXYhMX3ptuizUO+W8ZcfkXqbexFGbQFA+H9/N39ntsBFmGJwJBAPBhvQU/SJNrsbXN8ApsyGDTW2VaiHrzyIkzW1uCemW9Mbj2Ia9t1qhQ+lYIT9GP5f0Klo7OU4EwfXatNJ0vSUcCQDKs66QlNeH5JUFiB5Iq1iQuvUSh0wKKgjs5ZGGHZJkzHObABVyqVYu55KvtzKPPW4/VeKRxkWtVWsxYaX18tYkCQGMdCaD2POh8CSQbK5RA0kYKH68kqw13IwJfKJYMsIbugWfwJGd+9HkmGnIKr06K9JtnGDj9nbSw16ptNDpzWtUCQQCY3IcbwnUQQNWV3MaAEcZ1jix6+fJtIbTHyZpPk4EyrEfwPMt9ODgED6poTzV/2WElji92JvarPdQsTOOXDjc9";

        //private static string publicKey => @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCa11fMnpxUQKlfF3UzmCjIyHFGO1u6qkNQ9Ij9d6prSl6nC0KX8KjipofEfUw6Ny6ggrd6f+i/OTN5ySKtNdsGaOdK5nYkRbaQEOB257kitjxCOCeJGjWL4Np4+5JGcdzSPvRnnjOGrLXN6UpXIDV8+cB/eUoZ+KO431bUSD5T0QIDAQAB";

        private static string privateKey = @"MIICXAIBAAKBgQDBA6Rl2zhuBtQSEvkVpqWQwTnhwe2uGUSpIufFP2yLH0sbMPAjTkycQk9XGQnwsnjJ3V/ptbjGom2ILTd7hHJMtb9hhfcFRcOIKTMaMO3XD9nYI+R3xO2jhMu2bPVBLKTarKvmfklr8pvNjvetOaCbng3rwkkjcjv68kLZlhy3YQIDAQABAoGAB6QfxYKEvOJbUe3bW46R3mWv526YfLx2WeXOXCIzJ1zRSd3Jm/Q1FziO0Ilmudcu7frsGaH+kyqKAIqduC+ZoLsQgeT4cAotzNGGZRn0fANsE6fxEgxt7AcWCODnIWbEUsOHbeVFyjF/7SadVhO/+dJnmX/LGM/yw2RS/3QjanMCQQD8sJIAWk0KE7R17ZcRkaTrejf2lWuWVs3S4KykTrrLivpfPglDkVrS8PwR0DXli55c9TXtFLMbWgH//D1IXN4LAkEAw4rxHw+ew8TYDxzMWcO0P3+8MpC2ryjSVuN+Uc0f0lo0x13Wc1Zi/c/BZs5+94YoMAjI1mEgQ5XQlOUyElzfwwJBAKWXBCZtBp066oB5UQ03V07kybWyl01u1vSBPUFzQl/OVGKDociAgXdIarc1rYweYYnjOxKBBRpAcp0Q7Av2p58CQBqWdsihaBX4WuRbJxIBgS2tIZrCgIR6iXcVAaT/vhbs+wYspS8TjOwz5nkjFLJ1RFubpis4E5n88dp8+3zxsd8CQFFdPrYtaR8NaK/iPHk2NcvAdS5FPtOUu0FZJDy8X32agfADgFoaAp4r/6NPU2KQt6OvT8go9q//t3DI+U6NxdY=";
        private static string publicKey = @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDBA6Rl2zhuBtQSEvkVpqWQwTnhwe2uGUSpIufFP2yLH0sbMPAjTkycQk9XGQnwsnjJ3V/ptbjGom2ILTd7hHJMtb9hhfcFRcOIKTMaMO3XD9nYI+R3xO2jhMu2bPVBLKTarKvmfklr8pvNjvetOaCbng3rwkkjcjv68kLZlhy3YQIDAQAB";


        private static RSACryptoServiceProvider _privateKeyRsaProvider = CreateRsaProviderFromPrivateKey(privateKey);
        private static RSACryptoServiceProvider _publicKeyRsaProvider = CreateRsaProviderFromPublicKey(publicKey);

        public static string Decrypt(string cipherText)
        {
            if (_privateKeyRsaProvider == null)
            {
                throw new Exception("_privateKeyRsaProvider is null");
            }
            return Encoding.UTF8.GetString(_privateKeyRsaProvider.Decrypt(System.Convert.FromBase64String(cipherText), false));
        }

        public static string Encrypt(string text)
        {
            if (_publicKeyRsaProvider == null)
            {
                throw new Exception("_publicKeyRsaProvider is null");
            }
            return Convert.ToBase64String(_publicKeyRsaProvider.Encrypt(Encoding.UTF8.GetBytes(text), false));
        }



        //public static Dictionary<string, string> CreateRsaKeyPair()
        //{
        //    var keyPair = new Dictionary<string, string>();
        //    var rsaProvider = new RSACryptoServiceProvider(1024);
        //    RSAParameters parameter = rsaProvider.ExportParameters(true);
        //    keyPair.Add("PUBLIC", BytesToHexString(parameter.Exponent) + "," + BytesToHexString(parameter.Modulus));
        //    keyPair.Add("PRIVATE", rsaProvider.ToXmlString(true));
        //    return keyPair;
        //}
        private static string BytesToHexString(byte[] input)
        {
            StringBuilder hexString = new StringBuilder(64);

            for (int i = 0; i < input.Length; i++)
            {
                hexString.Append(String.Format("{0:X2}", input[i]));
            }
            return hexString.ToString();
        }


        private static RSACryptoServiceProvider CreateRsaProviderFromPrivateKey(string privateKey)
        {
            var privateKeyBits = System.Convert.FromBase64String(privateKey);

            var RSA = new RSACryptoServiceProvider();
            var RSAparams = new RSAParameters();

            using (BinaryReader binr = new BinaryReader(new MemoryStream(privateKeyBits)))
            {
                byte bt = 0;
                ushort twobytes = 0;
                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130)
                    binr.ReadByte();
                else if (twobytes == 0x8230)
                    binr.ReadInt16();
                else
                    throw new Exception("Unexpected value read binr.ReadUInt16()");

                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102)
                    throw new Exception("Unexpected version");

                bt = binr.ReadByte();
                if (bt != 0x00)
                    throw new Exception("Unexpected value read binr.ReadByte()");

                RSAparams.Modulus = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.Exponent = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.D = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.P = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.Q = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.DP = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.DQ = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.InverseQ = binr.ReadBytes(GetIntegerSize(binr));
            }

            RSA.ImportParameters(RSAparams);
            return RSA;
        }

        private static int GetIntegerSize(BinaryReader binr)
        {
            byte bt = 0;
            byte lowbyte = 0x00;
            byte highbyte = 0x00;
            int count = 0;
            bt = binr.ReadByte();
            if (bt != 0x02)
                return 0;
            bt = binr.ReadByte();

            if (bt == 0x81)
                count = binr.ReadByte();
            else
                if (bt == 0x82)
            {
                highbyte = binr.ReadByte();
                lowbyte = binr.ReadByte();
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                count = BitConverter.ToInt32(modint, 0);
            }
            else
            {
                count = bt;
            }

            while (binr.ReadByte() == 0x00)
            {
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);
            return count;
        }

        private static RSACryptoServiceProvider CreateRsaProviderFromPublicKey(string publicKeyString)
        {
            // encoded OID sequence for  PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"
            byte[] SeqOID = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
            byte[] x509key;
            byte[] seq = new byte[15];
            int x509size;

            x509key = Convert.FromBase64String(publicKeyString);
            x509size = x509key.Length;

            // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
            using (MemoryStream mem = new MemoryStream(x509key))
            {
                using (BinaryReader binr = new BinaryReader(mem))  //wrap Memory Stream with BinaryReader for easy reading
                {
                    byte bt = 0;
                    ushort twobytes = 0;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return null;

                    seq = binr.ReadBytes(15);       //read the Sequence OID
                    if (!CompareBytearrays(seq, SeqOID))    //make sure Sequence for OID is correct
                        return null;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8103) //data read as little endian order (actual data order for Bit String is 03 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8203)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return null;

                    bt = binr.ReadByte();
                    if (bt != 0x00)     //expect null byte next
                        return null;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return null;

                    twobytes = binr.ReadUInt16();
                    byte lowbyte = 0x00;
                    byte highbyte = 0x00;

                    if (twobytes == 0x8102) //data read as little endian order (actual data order for Integer is 02 81)
                        lowbyte = binr.ReadByte();  // read next bytes which is bytes in modulus
                    else if (twobytes == 0x8202)
                    {
                        highbyte = binr.ReadByte(); //advance 2 bytes
                        lowbyte = binr.ReadByte();
                    }
                    else
                        return null;
                    byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };   //reverse byte order since asn.1 key uses big endian order
                    int modsize = BitConverter.ToInt32(modint, 0);

                    int firstbyte = binr.PeekChar();
                    if (firstbyte == 0x00)
                    {   //if first byte (highest order) of modulus is zero, don't include it
                        binr.ReadByte();    //skip this null byte
                        modsize -= 1;   //reduce modulus buffer size by 1
                    }

                    byte[] modulus = binr.ReadBytes(modsize);   //read the modulus bytes

                    if (binr.ReadByte() != 0x02)            //expect an Integer for the exponent data
                        return null;
                    int expbytes = (int)binr.ReadByte();        // should only need one byte for actual exponent data (for all useful values)
                    byte[] exponent = binr.ReadBytes(expbytes);

                    // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                    RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                    RSAParameters RSAKeyInfo = new RSAParameters();
                    RSAKeyInfo.Modulus = modulus;
                    RSAKeyInfo.Exponent = exponent;
                    RSA.ImportParameters(RSAKeyInfo);

                    return RSA;
                }

            }
        }

        private static bool CompareBytearrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;
            int i = 0;
            foreach (byte c in a)
            {
                if (c != b[i])
                    return false;
                i++;
            }
            return true;
        }


    }
}
