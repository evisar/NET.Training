<?xml version = "1.0" encoding = "utf-8"?>
<xsl:stylesheet 
  version="1.0" 
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:a="CompanyA"
  xmlns:b="CompanyB">

  <xsl:output method="html" version="1.0" encoding="ISO-8859-1" indent="yes"/>

  <xsl:template match="/">
    <table>
    <thead>
      <tr>
        <td>Forename</td>
        <td>Surname</td>
      </tr>
    </thead>
    <tbody>
      <xsl:for-each select="/employees/a:employee">
        <tr>
          <td>
            <xsl:value-of select="@a:forename"/>
          </td>
          <td>
            <xsl:value-of select="@a:surname" />
          </td>
        </tr>
      </xsl:for-each>
      <xsl:for-each select="/employees/b:employee">
        <tr>
          <td>
            <xsl:value-of select="@b:forename"/>
          </td>
          <td>
            <xsl:value-of select="@b:surname" />
          </td>
        </tr>
      </xsl:for-each>
    </tbody>
    </table>
  </xsl:template>
</xsl:stylesheet>

