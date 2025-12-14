const WAIT_TIME = 2500;
const SCROLL_SPEED = 0.025;

function wait(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

function smoothScrollTo(targetY) {
    return new Promise(resolve => {
        const startY = window.scrollY;
        const distance = targetY - startY;
        const duration = Math.abs(distance) / SCROLL_SPEED;
        let startTime = null;

        function step(timestamp) {
            if (!startTime) startTime = timestamp;
            const elapsed = timestamp - startTime;
            const progress = Math.min(elapsed / duration, 1);

            window.scrollTo(0, startY + distance * progress);

            if (progress < 1) {
                requestAnimationFrame(step);
            } else {
                resolve();
            }
        }

        requestAnimationFrame(step);
    });
}

async function autoScrollLoop() {
    while (true) {
        await wait(WAIT_TIME);

        const bottom =
            document.documentElement.scrollHeight - window.innerHeight;
        await smoothScrollTo(bottom);

        await wait(WAIT_TIME);
        await smoothScrollTo(0);
    }
}

autoScrollLoop();