-- mathUtil.lua
-- 
-- 

local mathUtil = {}

function mathUtil.modPow(number, exponent, modulus)
	if modulus == 1 then return 0 end
	
	local result = 1
	number = number % modulus
	while exponent > 0 do
		if exponent % 2 == 1 then
			result = (result * number) % modulus
		end
		exponent = exponent >> 1
		number = (number * number) % modulus
	end
	
	return result
end

return mathUtil
