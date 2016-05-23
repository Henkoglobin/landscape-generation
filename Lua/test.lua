local blumblumshub = require("blumblumshub")
local random = blumblumshub(3)


local results = {}
for i = 1, 100000 do
	local value = math.floor(random:next() * 6) + 1
	results[value] = (results[value] or 0) + 1
end

for i = 1, 6 do
	print(("%d: %d"):format(i, results[i] or 0))
end