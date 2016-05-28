-- iterativePrimalityTest.lua
-- 
-- 

local function test(number)
	if number <= 1 then return false end
	if number == 2 then return true end
	
	for i = 2, math.sqrt(number) do
		if number % i == 0 then 
			return false 
		end
	end
	
	return true
end

return test
