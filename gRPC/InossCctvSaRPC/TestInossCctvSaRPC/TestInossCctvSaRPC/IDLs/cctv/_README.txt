
-----------------------------------------------------------------------------
20200810

https://www.jacorb.org/ (3.5)

>set JACORB_HOME=XPTO\jacorb-3.5\

>"%JACORB_HOME%\bin\idl" -d dest_dir -i2jpackage :com.efacec.es.inoss.stv.corba.jacorb  -all operation.idl
>"%JACORB_HOME%\bin\idl" -d dest_dir -i2jpackage :com.efacec.es.inoss.stv.corba.jacorb  -all configuration.idl
>"%JACORB_HOME%\bin\idl" -d dest_dir -i2jpackage :com.efacec.es.inoss.stv.corba.jacorb  -all AgenteStv.idl
>"%JACORB_HOME%\bin\idl" -d dest_dir -i2jpackage :com.efacec.es.inoss.stv.corba.jacorb  -all agentoper.idl
>"%JACORB_HOME%\bin\idl" -d dest_dir -i2jpackage :com.efacec.es.inoss.stv.corba.jacorb  -all EventConsumer.idl
>"%JACORB_HOME%\bin\idl" -d dest_dir -i2jpackage :com.efacec.es.inoss.stv.corba.jacorb  -all EventInfo.idl
>"%JACORB_HOME%\bin\idl" -d dest_dir -i2jpackage :com.efacec.es.inoss.stv.corba.jacorb  -all EventServer.idl
>"%JACORB_HOME%\bin\idl" -d dest_dir -i2jpackage :com.efacec.es.inoss.stv.corba.jacorb  -all EventTypes.idl
>"%JACORB_HOME%\bin\idl" -d dest_dir -i2jpackage :com.efacec.es.inoss.stv.corba.jacorb  -all stvevent.idl
>"%JACORB_HOME%\bin\idl" -d dest_dir -i2jpackage :com.efacec.es.inoss.stv.corba.jacorb  -all stv_types.idl
>"%JACORB_HOME%\bin\idl" -d dest_dir -i2jpackage :com.efacec.es.inoss.stv.corba.jacorb  -all types.idl
>"%JACORB_HOME%\bin\idl" -d dest_dir -i2jpackage :com.efacec.es.inoss.stv.corba.jacorb  -all qq_idl_adicionado_e_necessario.idl

Remover, do projecto IgStv, todas as classes/packages debaixo de com.efacec.es.inoss.stv.corba.jacorb.
Mover todas as pastas e ficheiros resultantes da execução do comando idl para o projecto IgStv.

Remover a keyword "final" da declaração da classe com.efacec.es.inoss.stv.corba.jacorb.stv.tao.RecordingStv_ para permitir a sua extensão.











-----------------------------------------------------------------------------
Versão antiga:

https://www.jacorb.org/ (3.5)

set JACORB_HOME=C:\D\Java\Utils\CORBA\jacORB\jacorb-3.5\



Como criar os ficheiros Java usando o JacORB e os IDLs necessários.
%JACORB_HOME%\bin\idl -d {whatever}\GISTV\trunk\_bak\corba -all *.idl

-all
-all generate code for all IDL files, even included ones (default is off). 
     If you want to make sure that for a given IDL no code will be generated 
	 even if this option is set, use the (proprietary) preprocessor directive 
	 #pragma inhibit code generation.
-i2jpackage x:a.b.c replace IDL package name x by a.b.c in generated Java code (e.g. CORBA:org.omg.CORBA)
	 

Como os IDLs não têm info "namespace", que criaria Javas com package, temos que criar 
os Java e enviar para uma pasta qq.

Ir às "sources", no projecto IgStv e remover a pasta onde os antigos .java gerados pelo jacorb.

Copiar todas as "sources", as possíveis pastas tb, para a raíz do projecto.

No NetBeans, seleccionar todos os ficheiros copiados (EXCLUÍNDO pastas), 
ir ao menu "Refactoring" do NB e seleccionar "move to package" "whatever". 

O NetBeans pode ficar algum tempo a "pensar" mas é normal e de seguida, "se tudo correr bem", 
apresentará uma janela que pergunta se se pretendem mover estes ficheiros fazendo "Refactoring",
respondendo sim.

Para as pastas, seleccionar a pasta e "Refactor" | "Rename" e adicionar, no início, "whatever". 
Ou seja, para a pasta XPTO, passar para "whatever".XPTO.


Voilá!


Normally, the default stv ig corba/jacorb package: com.efacec.es.inoss.stv.corba.jacorb







