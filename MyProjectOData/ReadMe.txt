ODATA Conventions

$Expand
Posts($select=Title;$expand=TypeOfPosts($select=Type))

$Select
ColumnName,...
ContractId, ContractReference
$select=Name, IcaoCode

$top, $skip
1,2,...

$filter
contains(Description,'Lorem')
ContractReference eq 'M00350'

eq - equals
ne - not equals
lt - less than
gt - greater than
le - less than and equals
ge - greater than and equals

and,or,not
startswith,endswith

(ContractReference eq 'M00350') and not (CostCentre eq '43')

startswith(ContractReference, 'M00')
endswith(ContractReference, '350')

wild card search
contains(ContractReference, 'M00')

nested filter
$expand=Trips($filter=Name eq 'Trip in US')

nested filter with wildcard
$expand=Clients($filter=contains(ContactName, 'Tes'))


$orderby
Name desc
Name asc or Name

$count
true - gives the count of the response

lambda
any,all
$filter =Clients/any(vr: vr/ContactName eq 'Tesco')

add,mul, div, sub

$filter = AMountOfCash div NumberOfRecords gt 10

Clients($expand=Receivables($expand=Retentions))
