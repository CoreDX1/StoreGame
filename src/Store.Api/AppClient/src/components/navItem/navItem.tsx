import { component$ } from "@builder.io/qwik";
import { Link } from "@builder.io/qwik-city";

interface Props {
    text: string;
    href: string;
}

export default component$<Props>(({ text, href }) => {
    return (
        <li class="hover:bg-gray-300 p-2 text-xl pl-12 w-full text-start">
            <Link href={href}>{text}</Link>
        </li>
    );
});
