<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:template match="/">
	<html>
	
		<center>
		<head>
			<title>File and System Watcher Log Report</title>
			<h1>File and System Watcher Log Report</h1>
		</head>
		<body>

		<table border="1" cellpadding="5" width="100%">
		<tr>
			<th>Name</th>
			<th>FullPath</th>
			<th>Change Type</th>
			<th>UserName</th>
			<th>Date of change</th>	
			<th>Time of change</th>	
		</tr>
		
		<xsl:for-each select="logs/log" >
		<xsl:sort select="Date" order="ascending" />
		<xsl:sort select="Time" order="descending" />
			<tr>
				<xsl:if test="ChangeType='Deleted'">
					<xsl:attribute name="bgcolor">red</xsl:attribute>
				</xsl:if>
				<td><xsl:value-of select="Name" /></td>
				<td><xsl:value-of select="FullPath" /></td>				
				<td><xsl:value-of select="ChangeType" /></td>
				<td><xsl:value-of select="UserName" /></td>
				<td><xsl:value-of select="Date" /></td>
				<td><xsl:value-of select="Time" /></td>					
			</tr>
			</xsl:for-each>		
		</table>
		</body>
		</center>
	</html>
</xsl:template>

</xsl:stylesheet>



