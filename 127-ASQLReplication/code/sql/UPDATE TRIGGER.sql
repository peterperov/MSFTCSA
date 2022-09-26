
/*
insert into Coffees(Coffee) VALUES ('151515') 


select * from Coffees

*/

DROP TRIGGER [dbo].[tr_Coffees_update]
GO

CREATE TRIGGER [dbo].[tr_Coffees_update] ON [dbo].[Coffees]
AFTER INSERT, UPDATE AS 
BEGIN

    SET NOCOUNT ON;


	update C
	set C.CreatedBy = SUSER_SNAME() 
	from Coffees C inner join inserted I 
		on C.RecordID = I.RecordID; 

END

GO
