<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
	<html>
		<body>
			<h1 align="center">Movies</h1>
			<table border="1" align="center">

				<!-- First row containing headers -->
				<tr bgcolor="#DCDCDC"> 
					<td><b>Rating</b></td>
					<td><b>Title</b></td> 
					<td><b>Runtime</b></td> 
					<td><b>Genre</b></td> 
					<td><b>Directors</b></td>
					<td><b>Director's High Rated Movie</b></td>
					<td><b>Studio</b></td>
					<td><b>Year</b></td>
				</tr>

				<!-- Rows containing values -->
				<xsl:for-each select="Movies/Movie">
					<tr style="font-size: 12pt; font-family: verdana">
						<td><xsl:value-of select="@rating"/></td>
						<td><xsl:value-of select="Title"/></td>
						<td><xsl:value-of select="Title/@runtime"/></td>
						<td><xsl:value-of select="Genre"/></td>

						<td>
							<!-- For multiple director elements -->
							<xsl:for-each select="Director">
								<xsl:value-of select="Name"/>
								<xsl:if test="position()!=last()">
									<xsl:text>,</xsl:text>
								</xsl:if>
							</xsl:for-each>
						</td>
						<td>
							<!-- For attribute high rated movie for multiple director -->
							<xsl:for-each select="Director/Name">
								<xsl:if test="@high-rated-movie!=''">
									<xsl:value-of select="First"/><xsl:text>:</xsl:text>
									<xsl:value-of select="@high-rated-movie"/>
								</xsl:if>
							</xsl:for-each>
						</td>
						<td><xsl:value-of select="Studio"/></td>
						<td><xsl:value-of select="Year"/></td>
					</tr>
				</xsl:for-each>
			</table>
		</body>
	</html>
</xsl:template>
</xsl:stylesheet>