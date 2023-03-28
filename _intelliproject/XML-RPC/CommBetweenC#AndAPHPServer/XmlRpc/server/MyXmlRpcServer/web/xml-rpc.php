<?php

include('IXR_Library.inc.php');
include('config.php');

function getServerTime($args) 
{
    return date('H:i:s');
}

function getCountryList($args)
{
    $args = explode(" ", $args);
    
    $szSQL = "SELECT * from country WHERE country_name LIKE '".$args[0]."%'";
    
    $conn = mysql_connect(DBHOST, DBUSER, DBPASS) or
            die ('Error connecting to mysql');
            
    mysql_select_db(DBNAME) or
            die ('Error selecting database');
    
    $result = mysql_query($szSQL) 
                or die(mysql_error());  
    
    $return_value = array();            
        
    while($row = mysql_fetch_array( $result ))
    {
        $return_value [] = array ('name'=>$row['country_name'],
                                  'iso'=>$row['iso'],  
                                  'flag_http'=>'http://localhost/MyXmlRpcServer/web/flags/'.strtolower($row['iso']).'.gif');    
    }
  
    mysql_close($conn);
    
    return json_encode($return_value);    
} 

function getCountryDetails($args)
{
    $args = explode(" ", $args);
    
    $szSQL = "SELECT * from country WHERE iso ='".$args[0]."'";
    
    $conn = mysql_connect(DBHOST, DBUSER, DBPASS) or
            die ('Error connecting to mysql');
            
    mysql_select_db(DBNAME) or
            die ('Error selecting database');
    
    $result = mysql_query($szSQL) 
                or die(mysql_error());  
    
    $return_value = array();            
        
    while($row = mysql_fetch_array( $result ))
    {
        $return_value [] = array ('name'=>$row['printable_name'],
                                  'iso'=>$row['iso'],  
                                  'iso3'=>$row['iso3'],
                                  'numcode'=>$row['numcode'],                                  
                                  'flag_http'=>'http://localhost/MyXmlRpcServer/web/flags/'.strtolower($row['iso']).'.gif');    
    }
  
    mysql_close($conn);
    
    return json_encode($return_value);
}

$server = new IXR_Server(array( 'xmlrpc.getServerTime' => 'getServerTime',                              
                                'xmlrpc.getCountryList' => 'getCountryList',
                                'xmlrpc.getCountryDetails' =>'getCountryDetails'  
                               ));

?>
