<?php

$curl = curl_init();

curl_setopt_array($curl, array(
  CURLOPT_URL => 'https://api.safaricom.co.ke/mpesa/accountbalance/v1/query',
  CURLOPT_RETURNTRANSFER => true,
  CURLOPT_ENCODING => '',
  CURLOPT_MAXREDIRS => 10,
  CURLOPT_TIMEOUT => 0,
  CURLOPT_FOLLOWLOCATION => true,
  CURLOPT_HTTP_VERSION => CURL_HTTP_VERSION_1_1,
  CURLOPT_CUSTOMREQUEST => 'POST',
  CURLOPT_POSTFIELDS =>'{
    "Initiator": "Enock",
    "SecurityCredential": "HToNsCLwNvvKMZXInHKmgn4tHjx8PNWx9zcpfw3zZc7Ss2odSR5xXCjmISB0zxchKU9zUPAMC0OawkHRD5YDP9fQ7db6UIWQuIpYJdqo/IdwowghUr8OcYwbtf6u4BpNPfHxxzgQFSSH6RnmwLbUYurzizufxMlQf4//IB+VfV7uHyh0x4iWLxHeUcaDamafluQ5iifcXR52mYs03vY31A6moo7V3/bydCRezrxaj8Ao2Zsns6Tsas457o8x1tNhtVTBnK9aDkAeO+y8ezCoys5R1l5kFmBuvhQ+aQD9y/jVpZGkRIWmMnT+xVoe5HVgxjj743T6HPo39f2wCervag==",
    "CommandID": "AccountBalance",
    "PartyA": "994805",
    "IdentifierType": "4",
    "Remarks": "check",
    "QueueTimeOutURL": "http://portal.lifewaychristianacademy.sc.ke/paybill/confirmation.php",
    "ResultURL": "http://portal.lifewaychristianacademy.sc.ke/paybill/confirmation.php"
}',
  CURLOPT_HTTPHEADER => array(
    'Authorization: Bearer ZI959723lhEZ8KIVbvFDt8IPA2r3',
    'Content-Type: application/json'
  ),
));

$response = curl_exec($curl);

curl_close($curl);
echo $response;
