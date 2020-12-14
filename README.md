# xs8Cipher
## **!!! DO NOT USE FOR SENSITIVE DATA !!!** 

Cipher written just for fun!

# The v2.0 is ~80% faster and more secure than the v1.0!

I've rewritten the entire algorithm, the new features:

- The algorithm uses a 4 round encryption
- 256bit blocks (easily editable)
- 256bit key / IV (easily editable)
- Based on the new [BLAKE3](https://github.com/azureskydiver/Blake3Core) hash algorithm (you can use any hashing algorithm, but be sure to use a strong cryptographic hashing algorithm, as this is used to generate the sub IVs/keys)
- Each round has his unique IV/KEY computed from BLAKE3

---

# OLD VERSION (1.0)

![Alt Text](https://i.imgur.com/Ltz4XvU.png)
**Photo From the v1.0**

Examples:

key **3t6w9z$C&F)J@Nc9** (128bit)

'Hello World' encrypted 5 times with the same key and encoded in *base64*

```
[0]: +2e6TonBFKGx3Y3hcIfz+gxJ/qUicpGOggiSQZQWCCc=
[1]: lWuMjW8ydqjeLyVFDkUOdke5jjlIpFFlVx4OOndm/AM=
[2}: j5YTcQCbUDs2zu+5SkZQ2xAdUhrXJ8j6O7+dlNDGckw=
[3]: ozgogJ6pRS8bSv6ivVuDucSpNWYHXZC6GKHQtptHhVs=
[4]: OEnob+xZQRTtHxk0WDDJV3fTVEWRLgVQOfp3f6edz5I=
```

Image encrypted 2 times with the same key:

**Original Image**

![Alt Text](https://www.lpi.org/sites/default/files/LPI-CODE_0.jpg)

**Encrypted Image [0]**

![Alt Text](https://i.imgur.com/w0UWMKp.png)

**Encrypted Image [1]**

![Alt Text](https://i.imgur.com/iifeENl.png)

## I'm NOT an expert so please do not use this cipher to encrypt your sensitive data, can be dangerous and I'll not assume any responsibility for how you will use it!
