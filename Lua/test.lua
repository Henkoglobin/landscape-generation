local integer = require("integer")
local blumblumshub = require("blumblumshub")
local random = blumblumshub(3)

print("integer.maxValue: " .. tostring(integer.maxValue) .. ", " .. tostring(integer.maxValue - 1))
print("num bits: " .. tostring(math.log(integer.maxValue) / math.log(2)) .. " + sign bit")

local results = {}
for i = 1, 100000 do
	local value = random:next(1, 6)
	results[value] = (results[value] or 0) + 1
end

for i = 0, 7 do
	print(("%d: %d"):format(i, results[i] or 0))
end
