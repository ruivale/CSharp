About:
======
This package provides a simple XML-RPC client and server for C#
applications. It's pure C#, using .Net for networking and
XML functionality.

What separates this from XML-RPC.Net? This is much lower tech, no
required attributes, no proxies, no IIS. 

Features:
=========
	- full xmlrpc.org spec implementation
	- basic client (XmlRpcRequest)
	- Embedded server (XmlRpcServer)
	- Introspection System object (XmlRpcSystemObject)
	- optional XML-RPC specific method access attribute
	  over and above C#'s "public" (XmlRpcExposedAttribute) 

Prerequisites To build:
=======================
	- Have a new .NET SDK loaded
	- Have csc and friends in your PATH.
	- Put nant/bin into your PATH 
	      - nant is an OpenSource C# build tool, binaries included in
	      ./nant, or see http://nant.sourceforge.net

To Build:
=========
In a command shell:

   nant

Basic Test:
===========
Open two command shells, in one:

     server

In the other:

     client

Sample Code:
============
Under src/samples there are examples. There is a simple server, a simple
client, an example using the system object remotely and a server using the
optional XmlRpcExposed attribute.

ToDo:
=====
	- Standard Fault codes
	- Better exception handling
	- Support the rest of XML-RPC "system" Object
		  - boxcaring
		  - capabilities
	- Documentation
	- Threading/performance
	- optimize
	- Test with Mono

Changes:
========
Version	Date		Change
------- --------	--------------------------------------------------------------------------------
1.2			Introspection via "system" object
			Added optional XmlRpcExposed Attribute
			Moved to using "is" operator...damn C# is syntax fat
			Fix known deserializer bug pertaining to containers (array/struct) in containers

1.1	20030128	Bug fix in request deserializer
			Better samples
			response.FaultCode/.FaultString added
			indentention on the XML in ToString of request/response

1.0	20030125	Support for base64
			Use .Net's XmlWriter
			Centralize XML-RPC tokens into XmlRpcXmlTokens

