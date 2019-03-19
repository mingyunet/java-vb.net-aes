Imports System.Text

Public Class AesUtil
    'AES加密
    Public Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        If input.Trim().Length() = 0 Then
            Return ""
        End If

        Dim toEncryptArray() As Byte = Encoding.UTF8.GetBytes(input)

        Dim rm As New System.Security.Cryptography.RijndaelManaged
        rm.Key = Encoding.UTF8.GetBytes(pass)
        rm.Mode = Security.Cryptography.CipherMode.ECB
        rm.Padding = Security.Cryptography.PaddingMode.PKCS7

        Dim cTransform As System.Security.Cryptography.ICryptoTransform = rm.CreateEncryptor
        Dim resultArray() As Byte = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)

        Return Convert.ToBase64String(resultArray, 0, resultArray.Length)
    End Function


    'AES解密
    Public Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
        If input.Trim().Length() = 0 Then
            Return ""
        End If
        Dim toEncryptArray() As Byte = Convert.FromBase64String(input)
        Dim rm As New System.Security.Cryptography.RijndaelManaged
        rm.Key = Encoding.UTF8.GetBytes(pass)
        rm.Mode = Security.Cryptography.CipherMode.ECB
        rm.Padding = Security.Cryptography.PaddingMode.PKCS7
        Dim cTransform As System.Security.Cryptography.ICryptoTransform = rm.CreateDecryptor
        Dim resultArray() As Byte = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
        Return Encoding.UTF8.GetString(resultArray)
    End Function

End Class
