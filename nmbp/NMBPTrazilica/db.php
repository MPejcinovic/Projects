<?php // db.php

$dbhost = 'localhost';
$dbuser = 'postgres';
$dbpass = 'mihaela';

error_get_last();

    
    $db = pg_connect("host=$dbhost port=5432 dbname=Trazilica user=$dbuser password=$dbpass") 
        or die ("Could not connect to server\n"); 
    

?>