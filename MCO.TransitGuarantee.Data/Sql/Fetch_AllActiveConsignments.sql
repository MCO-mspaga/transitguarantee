﻿Select cons.consignment_number,
       sup.supplier_name,
       cons.booked_in_date,
       cons.booked_in_time,
       cons.ship_nametruck_plat,
       cons.carrier_code,
       cons.ETA_at_port,
       cons.Inland_Depot,
       cons.customs_entered
  From mackays.shp_consignments cons,
       ref_supplier sup
Where  cons.inland_depot in (@0)
And    cons.clearance_agent = sup.supplier_account
And    cons.booked_in_date =  (@1)  
Order by consignment_number asc