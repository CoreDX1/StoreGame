import { component$ } from "@builder.io/qwik";
import NavItem from "../navItem/navItem";

export default component$(() => {
    return (
        <header class="min-h-screen flex justify-center bg-gray-100">
            <ul class="flex flex-col gap-5 text-lg font-bold tracking-[2.1px] pt-5">
                <NavItem href="/" text="Home" />
                <NavItem href="/auth/admin/dashboard" text="Dashboard" />
                <NavItem href="/auth/admin/profile" text="Profile" />
                <NavItem href="/auth/admin/table" text="Table" />
            </ul>
        </header>
    );
});
