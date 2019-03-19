package com.pmcc.test;

import javax.crypto.Cipher;
import javax.crypto.spec.SecretKeySpec;
import sun.misc.BASE64Decoder;
import sun.misc.BASE64Encoder;


public class AesUtil {
	public static String aesEncrypt(String str, String key) throws Exception {
		if (str == null || key == null)
			return null;
		Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
		cipher.init(Cipher.ENCRYPT_MODE, new SecretKeySpec(key.getBytes("utf-8"), "AES"));
		byte[] bytes = cipher.doFinal(str.getBytes("utf-8"));
		return new BASE64Encoder().encode(bytes);
	}

	public static String aesDecrypt(String str, String key) throws Exception {
		if (str == null || key == null)
			return null;
		Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
		cipher.init(Cipher.DECRYPT_MODE, new SecretKeySpec(key.getBytes("utf-8"), "AES"));
		byte[] bytes = new BASE64Decoder().decodeBuffer(str);
		bytes = cipher.doFinal(bytes);
		return new String(bytes, "utf-8");
	}

	public static void main(String[] args) throws Exception {
		String s = "hello world 2019";
		String key = "qwer1234asdf5678";
		System.out.println("秘钥前:" + key);
		System.out.println("加密前:" + s);
		String s1 = aesEncrypt(s, key);
		System.out.println("加密后:" + s1);
		System.out.println("解密后:" + aesDecrypt(s1, key));
	}
}
