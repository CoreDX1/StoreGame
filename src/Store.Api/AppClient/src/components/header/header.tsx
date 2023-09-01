import { component$ } from "@builder.io/qwik";
import NavLink from "../NavLink/NavLink";
import Search from "../Search/Search";

export default component$(() => {
    return (
        <header class="pt-2  w-[930px] mx-auto">
            <div>
                <div>
                    <ul class="flex justify-end gap-5">
                        <li>
                            <a href="#">INICIAR SESIÓN</a>
                        </li>
                        <li>
                            <a href="#">CREAR CUENTA</a>
                        </li>
                    </ul>
                </div>
                <div class="text-start w-full flex justify-center">
                    <img
                        height={10}
                        width={50}
                        src="https://flowbite.com/docs/images/logo.svg"
                        class="mr-3 h-6 sm:h-9"
                        alt="Flowbite Logo"
                    />
                    <Search />
                </div>
                <nav class="bg-white border-gray-200 px-4 lg:px-6 py-2.5 ">
                    <div class="flex flex-wrap justify-between items-center mx-auto max-w-screen-xl">
                        <a href="http://localhost:5173" class="flex items-center">
                            <span class="self-center text-xl font-semibold whitespace-nowrap dark:text-white">
                                Flowbite
                            </span>
                        </a>
                        <div class="flex items-center lg:order-2">
                            <button
                                data-collapse-toggle="mobile-menu-2"
                                type="button"
                                class="inline-flex items-center p-2 ml-1 text-sm text-gray-500 rounded-lg lg:hidden hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200 dark:text-gray-400 dark:hover:bg-gray-700 dark:focus:ring-gray-600"
                                aria-controls="mobile-menu-2"
                                aria-expanded="false"
                            ></button>
                        </div>
                        <div
                            class="hidden justify-between items-center w-full lg:flex lg:w-auto lg:order-1"
                            id="mobile-menu-2"
                        >
                            <ul class="flex flex-col mt-4 font-medium lg:flex-row lg:space-x-8 lg:mt-0">
                                <NavLink href="http://localhost:5173" name="Home" />
                                <NavLink href="http://localhost:5173/games" name="Games" />
                                <NavLink href="http://localhost:5173/prevents" name="Prevents" />
                            </ul>
                        </div>
                    </div>
                </nav>
            </div>
        </header>
    );
});
