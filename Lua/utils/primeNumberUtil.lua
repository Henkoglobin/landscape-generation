-- primeNumberUtils.lua
-- 
-- 

local primeNumberUtils = {}

function primeNumberUtils.getPrimes(test)
	local progress = 0
	return function()
		if progress == 0 then
			progress = 2
			return 2
		end
		
		while(true) do
			progress = progress + 1
			if(test(progress)) then
				return progress
			end
		end
	end
end

return primeNumberUtils
