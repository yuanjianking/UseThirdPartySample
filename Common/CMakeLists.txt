# CMakeList.txt: 顶层 CMake 项目文件，在此处执行全局配置
# 并包含子项目。
#
cmake_minimum_required (VERSION 3.8)


#set(CMAKE_SYSTEM_PROCESSOR arm)
#SET(CMAKE_SYSTEM_NAME Linux)
#set(USER_PATH "/home/work/tools/aarch64-linux-gnu")
#SET(CMAKE_C_COMPILER ${USER_PATH}/bin/aarch64-none-linux-gnu-gcc)
#SET(CMAKE_CXX_COMPILER ${USER_PATH}/bin/aarch64-none-linux-gnu-g++)
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -fms-extensions")

set(LIBRARY_OUTPUT_PATH  "../../../../../../ThirdParty/Common")

project ("CommonLib")

# 包含子项目。
add_subdirectory ("CommonLib")