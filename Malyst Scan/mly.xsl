<xsl:stylesheet version="1.0" 
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match = "/" >
<html>
<head><title>Malyst</title></head>
<style>
.hdr { background-color=#ffeedd; font-weight=bold; }
</style>
<body>
<B>Answer suite</B>
<table style="border-collapse:collapse" border="1" padding="1">
<tr>
  <td class="hdr">Suite</td>
  <td class="hdr">Problem's ID</td>
  <td class="hdr">Questions</td>
  <td class="hdr">Wrong mark</td>
  <td class="hdr">Answer</td>
</tr>
<xsl:for-each select="//correct">
<tr>
  <td><xsl:value-of select="suite"/></td>
  <td><xsl:value-of select="problem"/></td>
  <td><xsl:value-of select="questions"/></td>
  <td><xsl:value-of select="wrond"/></td>
  <td><xsl:value-of select="answer"/></td>
</tr>
</xsl:for-each>
</table>
</body>
</html>
</xsl:template>
</xsl:stylesheet>