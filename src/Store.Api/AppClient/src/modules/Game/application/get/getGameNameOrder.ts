import { type BaseResponse } from "~/modules/types/BaseResponse";
import { type GameResponse } from "../../Domain/GameResponse";

export async function getGameNameOrder(): Promise<BaseResponse<GameResponse[]>> {
    const game = await fetch("http://localhost:5099/api/Game/order");
    const json = await game.json();
    return json;
}
