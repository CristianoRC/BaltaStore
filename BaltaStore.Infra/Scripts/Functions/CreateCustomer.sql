CREATE OR REPLACE FUNCTION public.CreateCustomer
                    (text,varchar,varchar,varchar,varchar,varchar)
RETURNS void
LANGUAGE plpgsql
AS 
$function$
BEGIN
    insert into Customer values($1,$2,$3,$4,$5,$6);
END;
$function$