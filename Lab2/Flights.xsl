<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output
     method="html"></xsl:output>
  <xsl:template match="/">
    <html>
      <body>
        <table border ="1">
          <TR>
            <th>Number</th>
            <th>Company</th>
            <th>From</th>
            <th>To</th>
            <th>Type</th>
            <th>Depature</th>
            <th>Arrival</th>
          </TR>
          <xsl:for-each select = "Flights/Flight">
            <tr>
              <td>
                <xsl:value-of select ="@Number"/>
              </td>
              <td>
                <xsl:value-of select ="@Company"/>
              </td>
              <td>
                <xsl:value-of select ="@From"/>
              </td>
              <td>
                <xsl:value-of select ="@To"/>
              </td>
              <td>
                <xsl:value-of select ="@Type"/>
              </td>
              <td>
                <xsl:value-of select ="@Depature"/>
              </td>
              <td>
                <xsl:value-of select ="@Arrival"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>