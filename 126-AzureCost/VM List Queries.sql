

select S.Server_Name
	, I.VM
	, S.CPU
	, S.RAM
	, S.*
from [Server] S
left outer join Inventory I on S.Server_Name = I.VM
where Wave not in ('Out Of Scope')