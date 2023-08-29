import { component$ } from "@builder.io/qwik";

interface ItemProps {
    name: string;
    href: string;
}

export default component$<ItemProps>((prop) => {
    return (
        <li>
            <a
                href={prop.href}
                class="tracking-widest block text-xl py-2 pr-4 pl-3 text-black border-gray-100 hover:text-gray-400"
            >
                {prop.name}
            </a>
        </li>
    );
});
