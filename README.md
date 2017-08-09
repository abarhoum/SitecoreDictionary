# Sitecore Alphabet Dictionary


<h3>Video</h3>
<a href='https://youtu.be/IOayM46EIAE'>https://youtu.be/IOayM46EIAE</a>

<h3>Sitecore Versions</h3>
SX P8.2 :  Supports Sitecore 8.2 only, It will not work on earlier Sitecore versions as it is using the new Sitecore Custom cache functionality.

<h3>Features</h3>

- Built on Helix Principles. 
- Using Sitecore search APIs.
- Using Sitecore Custom Cache.
- Define the Dictionary location path and Cache key for the each Site.
- Create Cache object for each Site and each language as well.

<h3>Installing and Configurations</h3>

- Download the SitecoreAlphabetDictionary-1.0.zip Package
- Navigate to "\App_Config\Include\Foundation\Foundation.SitecoreCache.config" to change the cache site if you want
 <b> Sitecore.Foundation.SitecoreCache.CacheSize : by default is 20MB</b>
 
 <h3>Uninstall Module</h3>
 
 - Remove "\App_Config\Include\Foundation\Foundation.SitecoreCache.config"
 - Remove "\App_Config\Include\Foundation\Foundation.Dictionary.config"
 - From Sitecore remove :/sitecore/templates/Foundation/Dictionary/
