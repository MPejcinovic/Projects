<?php // common.php

function error($msg) {
    ?>
    <!DOCTYPE html>
    <html lang="en">
    <head>
      <meta charset="UTF-8" />
      <script language="JavaScript">
      <!--
          alert("<?=$msg?>");
          history.back();
      //-->
      </script>
    </head>
    <body>
    </body>
    </html>
    <?
    exit;
}

?>