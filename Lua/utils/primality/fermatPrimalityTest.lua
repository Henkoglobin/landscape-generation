-- fermatPrimalityTest.lua
-- 
-- 

local mathUtil = require("utils.mathUtil")
local tests = { 2, 3 }


local function test(number)
	if number < 2 then return false end
	if number ~= 2 and number % 2 == 0 then return false end 
	
	for _, test in pairs(tests) do
		if mathUtil.modPow(test, number - 1, number) ~= 1 then
			return false
		end
	end
	
	return true
end

return test
